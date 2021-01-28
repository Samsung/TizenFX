/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;


using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Utility
{

  /// <summary>
  /// This is a class for stroing the text of a page.
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  class PageData
  {
    public string previousTag  {get; set;}
    public string endTag {get; set;}
    public int startOffset {get; set;}
    public int endOffset {get; set;}
  }

  /// <summary>
  /// This is a class that stores information when parsing markup text.
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  class TagData
  {
    public string tagName {get; set;}
    public string attributeName {get; set;}
    public bool isEndTag {get; set;}
  }

  /// <summary>
  /// This is utility class for paging very long text.
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class TextPageUtil
  {
    private static char LESS_THAN      = '<';
    private static char GREATER_THAN   = '>';
    private static char EQUAL          = '=';
    private static char QUOTATION_MARK = '\'';
    private static char SLASH          = '/';
    private static char BACK_SLASH     = '\\';
    private static char AMPERSAND      = '&';
    private static char HASH           = '#';
    private static char SEMI_COLON     = ';';
    private static char CHAR_ARRAY_END = '\0';
    private static char HEX_CODE       = 'x';
    private static byte WHITE_SPACE    = 0x20;

    private static int TEXTPAGE_TEXT_CHUNK = 20000;

    private int totalPageCnt;

    private List<PageData> pageList;
    private List<TagData> tagList;
    private StringReader stream;
    private List<char> characterList;
    private string pageString;

    /// <summary>
    /// When text is inputed, the text is paging in the TextLabe size unit.
    /// <returns>The total number of pages.</returns>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int SetText(TextLabel label, string str)
    {
      if(str == null) return 0;

      // perform this operation to match the utf32 character used in native Dali.
      bool previousMarkup = label.EnableMarkup;
      label.EnableMarkup = false;
      label.Text = str;
      pageString = label.Text;
      label.EnableMarkup = previousMarkup;
      label.MultiLine = true;
      label.Ellipsis = false;

      int length = pageString.Length;
      int remainLength = length;
      int offset = 0;
      int cutOffIndex = 0;

      // init
      pageList = new List<PageData>();
      tagList = new List<TagData>();
      characterList = new List<char>();

      stream = new StringReader(pageString);

      RendererParameters textParameters = new RendererParameters();
      textParameters.Text = pageString;
      textParameters.HorizontalAlignment = label.HorizontalAlignment;
      textParameters.VerticalAlignment = label.VerticalAlignment;
      textParameters.FontFamily = label.FontFamily;
      textParameters.FontWeight = "";
      textParameters.FontWidth = "";
      textParameters.FontSlant = "";
      textParameters.Layout = TextLayout.MultiLine;
      textParameters.TextColor = Color.Black;
      textParameters.FontSize = label.PointSize;
      textParameters.TextWidth = (uint)label.Size.Width;
      textParameters.TextHeight = (uint)label.Size.Height;
      textParameters.EllipsisEnabled = true;
      textParameters.MarkupEnabled = previousMarkup;


      Tizen.NUI.PropertyArray cutOffIndexArray = TextUtils.GetLastCharacterIndex( textParameters );
      uint count = cutOffIndexArray.Count();
      for(uint i=0; i < count; i++)
      {
          cutOffIndexArray.GetElementAt(i).Get(out cutOffIndex); // Gets the last index of text shown on the actual screen.

          // If markup is enabled, It should parse markup
          if(label.EnableMarkup)
          {
            int preOffset = offset;
            offset = MarkupProcess( offset, cutOffIndex - preOffset );
            remainLength -= (offset - preOffset);
          }
          //If markup is not enabled, parsing is not required.
          else
          {
            PageData pageData = new PageData();
            pageData.startOffset = offset;
            int cnt = (cutOffIndex - offset ) < remainLength ? (cutOffIndex - offset ) : remainLength;
            remainLength -= cnt;
            offset += cnt;
            pageData.endOffset = offset;
            pageList.Add(pageData);
          }
          totalPageCnt++;
          if(offset <= 0 ) break;
      }

      stream = null;
      return totalPageCnt;
    }

    /// <summary>
    /// Input the page number returns the text of the page.
    /// <returns>The text of the page.</returns>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetText(int pageNum)
    {
      if( pageNum > totalPageCnt || pageNum < 1 ) {
          Tizen.Log.Error("NUI", $"Out of Range total page count : {totalPageCnt}, input page number : {pageNum}\n");
          return "";
      }

      List<PageData> dataList = pageList.GetRange(pageNum-1, 1);
      foreach(PageData data in dataList)
      {
        int cnt = data.endOffset - data.startOffset;
        char[] charArray = new char[cnt];
        pageString.CopyTo(data.startOffset, charArray, 0, cnt);
        string pageText = data.previousTag+new String(charArray)+data.endTag;
        return pageText;
      }
      return "";
    }

    private void SkipWhiteSpace(ref int offset)
    {
      int character;
      while( ( character = stream.Read()) != -1)
      {
        offset++;
        if( character == WHITE_SPACE) continue;
        else break;
      }
    }

    private bool IsTag(TagData tag, ref int offset)
    {
      List<char> tagChaList = new List<char>();

      bool isTag = false;
      bool isQuotationOpen = false;
      bool attributesFound = false;
      tag.isEndTag = false;
      bool isPreviousLessThan = true;
      bool isPreviousSlash = false;

      int character;

      tag.tagName = "";
      tag.attributeName = "";
      // SkipWhiteSpace(ref offset);
      while((!isTag) && ((character = stream.Read()) != -1)) {
        offset++;
        characterList.Add((char)character);
        if( !isQuotationOpen && ( SLASH == character ) ) // '/'
        {
          if (isPreviousLessThan)
          {
            tag.isEndTag = true;
          }
          else
          {
            // if the tag has a '/' it may be an end tag.
            isPreviousSlash = true;
          }
          isPreviousLessThan = false;
          // SkipWhiteSpace(ref offset);
        }
        else if( GREATER_THAN == character ) // '>'
        {
          isTag = true;
          if (isPreviousSlash)
          {
            tag.isEndTag = true;
          }

          if(!attributesFound) {
            tag.tagName = new String(tagChaList.ToArray());
          } else {
            tag.attributeName = new String(tagChaList.ToArray());
          }

          isPreviousSlash = false;
          isPreviousLessThan = false;
        }
        else if( QUOTATION_MARK == character )
        {
          tagChaList.Add((char)character);
          isQuotationOpen = !isQuotationOpen;

          isPreviousSlash = false;
          isPreviousLessThan = false;
        }
        else if( WHITE_SPACE >= character || EQUAL == character ) // ' ', '='
        {
          // Let's save tag name.
          if(!attributesFound) {
            tag.tagName = new String(tagChaList.ToArray());
            tagChaList.Clear();
          }
          tagChaList.Add((char)character);
          // If the tag contains white spaces then it may have attributes.
          if( !isQuotationOpen )
          {
            attributesFound = true;
          }
        }
        else
        {
          tagChaList.Add((char)character);
          isPreviousSlash = false;
          isPreviousLessThan = false;
        }
      }
      return isTag;
    }


    private int MarkupProcess(int startOffset, int cutOffIndex)
    {

      int count = 0;
      int offset = startOffset;
      int character = 0;
      characterList.Clear();
      PageData pageData = new PageData();

      pageData.startOffset = offset;

      bool isPreviousLessThan = false;
      bool isPreviousSlash = false;

      // If the markup was previously open, the markup tag should be attached to the front.
      string tag ="";
      foreach (TagData data in tagList)
      {
        tag += "<"+data.tagName+data.attributeName+">";
      }
      pageData.previousTag = tag;


      bool isTag = false;
      while( (character = stream.Read()) != -1 )
      {
        offset++;
        characterList.Add((char)character);

        TagData tagData = new TagData();
        isTag = false;
        if( LESS_THAN == character ) // '<'
        {
          isTag = IsTag(tagData, ref offset);
        }

        if(isTag) {
          if(tagData.isEndTag) {
            int lastIndex = tagList.Count;
            tagList.RemoveAt(lastIndex-1);
          } else {
            tagList.Add(tagData);
          }
        } else {
          count++;
        }
        if(count >= cutOffIndex) break;

      }

      // If the markup was previously open, you should attach the label tag.
      tag ="";
      foreach (TagData data in tagList)
      {
        tag = "</"+data.tagName+">" + tag;
      }
      pageData.endTag = tag;

      pageData.endOffset = offset;
      pageList.Add(pageData);

      if(character == -1) offset = -1;
      return offset;
    }

  }
}