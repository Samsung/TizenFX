<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" version="1.0" encoding="UTF-8"
        indent="yes" />
    <xsl:template match="/">
        <html>
            <STYLE type="text/css">
                @import "./style/tests.css";
            </STYLE>
            <head>
                <script type="text/javascript" src="./style/jquery.min.js" />
                <script type="text/javascript" src="./style/popup.js" />
            </head>
            <body>
                <div id="title">
                    <table>
                        <tr>
                            <td class="title">
                                <h1 align="center">Suite Test Results</h1>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="btc">
                    <table>
                        <tr>
                            <td>
                                <a href="#" class="see_all">Show all</a>
                            </td>
                            <td>
                                <a href="#" class="see_failed">Show only failed</a>
                            </td>
                            <td>
                                <a href="#" class="see_blocked">Show only blocked</a>
                            </td>
                            <td>
                                <a href="#" class="see_na">Show only not executed</a>
                            </td>
                            <td>
                                <a href="summary.xml">Summary</a>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="testcasepage">
                    <div id="cases">
                        <div id="see_all">
                            <xsl:for-each select="test_definition/suite">
                                <xsl:sort select="@name" />
                                <div id="suite_title">
                                    <h2>
                                        Test Suite:
                                        <xsl:value-of select="@name" />
                                        (All)
                                    </h2>
                                    <a>
                                        <xsl:attribute name="name">
                                                                     <xsl:value-of
                                            select="@name" />
                                                                  </xsl:attribute>
                                    </a>
                                </div>
                                <table>
                                    <tr>
                                        <th>Case_ID</th>
                                        <th>Purpose</th>
                                        <th>Result</th>
                                        <th>Stdout</th>
                                    </tr>
                                    <xsl:for-each select=".//set">
                                        <xsl:sort select="@name" />
                                        <tr>
                                            <xsl:choose>
                                                <xsl:when test="@name">
                                                    <td colspan="3">
                                                        <h3>
                                                            Test Set:
                                                            <xsl:value-of select="@name" />
                                                        </h3>
                                                    </td>
                                                    <td colspan="1">
                                                        <h4>
                                                            <a>
                                                                <xsl:attribute name="href"><xsl:value-of
                                                                    select="@set_debug_msg" /></xsl:attribute>
                                                                dlog
                                                            </a>
                                                        </h4>
                                                    </td>
                                                </xsl:when>
                                                <xsl:otherwise>
                                                    <td colspan="4">
                                                        <h3>
                                                            Test Set:
                                                            <xsl:value-of select="@name" />
                                                        </h3>
                                                    </td>
                                                </xsl:otherwise>
                                            </xsl:choose>
                                        </tr>
                                        <xsl:for-each select=".//testcase">
                                            <xsl:sort select="@id" />
                                            <tr>
                                                <td>
                                                    <div
                                                        style="background-color:#F5DEB3;border:1px solid black;display:none;">
                                                        <xsl:attribute name="id"><xsl:value-of
                                                            select="@id" /></xsl:attribute>
                                                        <p>
                                                            <xsl:for-each select="./description/steps//step">
                                                                <xsl:sort select="@order" />
                                                                <B>
                                                                    Step
                                                                    <xsl:value-of select="@order" />
                                                                    :
                                                                </B>
                                                                <br />
                                                                <xsl:value-of select=".//step_desc" />
                                                                <br />
                                                                <B>Expected:</B>
                                                                <xsl:value-of select=".//expected" />
                                                                <br />
                                                            </xsl:for-each>
                                                        </p>
                                                        <p>
                                                            <br />
                                                            <B>
                                                                Entry:
                                                                <br />
                                                            </B>
                                                            <xsl:value-of select="./description//test_script_entry" />
                                                            <br />
                                                        </p>
                                                    </div>
                                                    <a href="#" class="test_case_popup">
                                                        <xsl:attribute name="id"><xsl:value-of
                                                            select="@id" /></xsl:attribute>
                                                        <xsl:value-of select="@id" />
                                                    </a>
                                                </td>
                                                <td>
                                                    <xsl:value-of select="@purpose" />
                                                </td>

                                                <xsl:choose>
                                                    <xsl:when test="@result">
                                                        <xsl:if test="@result = 'FAIL'">
                                                            <td class="red_rate">
                                                                <xsl:value-of select="@result" />
                                                            </td>
                                                        </xsl:if>
                                                        <xsl:if test="@result = 'PASS'">
                                                            <td class="green_rate">
                                                                <xsl:value-of select="@result" />
                                                            </td>
                                                        </xsl:if>
                                                        <xsl:if test="@result = 'BLOCK' ">
                                                            <td class="orange_rate">
                                                                BLOCK
                                                            </td>
                                                        </xsl:if>
                                                        <xsl:if
                                                            test="@result != 'BLOCK' and @result != 'FAIL' and @result != 'PASS' ">
                                                            <td class="gray_rate">
                                                                Not Run
                                                            </td>
                                                        </xsl:if>
                                                    </xsl:when>
                                                    <xsl:otherwise>
                                                        <td>

                                                        </td>
                                                    </xsl:otherwise>
                                                </xsl:choose>
                                                <td>
                                                    <xsl:call-template name="br-replace">
                                                        <xsl:with-param name="word"
                                                            select=".//result_info/stdout" />
                                                    </xsl:call-template>
                                                    <xsl:if test=".//result_info/stdout = ''">
                                                        N/A
                                                    </xsl:if>
                                                </td>
                                            </tr>
                                        </xsl:for-each>
                                    </xsl:for-each>
                                </table>
                            </xsl:for-each>
                        </div>
                        <div id="see_fail" style="display:none;">
                            <xsl:for-each select="test_definition/suite">
                                <xsl:sort select="@name" />
                                <div id="suite_title">
                                    <h2>
                                        Test Suite:
                                        <xsl:value-of select="@name" />
                                        (Failed only)
                                    </h2>
                                    <a>
                                        <xsl:attribute name="name">
                                                                     <xsl:value-of
                                            select="@name" />
                                                                  </xsl:attribute>
                                    </a>
                                </div>
                                <table>
                                    <tr>
                                        <th>Case_ID</th>
                                        <th>Purpose</th>
                                        <th>Result</th>
                                        <th>Stdout</th>
                                    </tr>
                                    <xsl:for-each select=".//set">
                                        <xsl:sort select="@name" />
                                        <tr>
                                            <xsl:choose>
                                                <xsl:when test="@name">
                                                    <td colspan="3">
                                                        <h3>
                                                            Test Set:
                                                            <xsl:value-of select="@name" />
                                                        </h3>
                                                    </td>
                                                    <td colspan="1">
                                                        <h4>
                                                            <a>
                                                                <xsl:attribute name="href"><xsl:value-of
                                                                    select="@set_debug_msg" /></xsl:attribute>
                                                                dlog
                                                            </a>
                                                        </h4>
                                                    </td>
                                                </xsl:when>
                                                <xsl:otherwise>
                                                    <td colspan="4">
                                                        <h3>
                                                            Test Set:
                                                            <xsl:value-of select="@name" />
                                                        </h3>
                                                    </td>
                                                </xsl:otherwise>
                                            </xsl:choose>
                                        </tr>
                                        <xsl:for-each select=".//testcase[@result='FAIL']">
                                            <xsl:sort select="@id" />
                                            <tr>
                                                <td>
                                                    <div
                                                        style="background-color:#F5DEB3;border:1px solid black;display:none;">
                                                        <xsl:attribute name="id">fail_<xsl:value-of
                                                            select="@id" /></xsl:attribute>
                                                        <p>
                                                            <xsl:for-each select="./description/steps//step">
                                                                <xsl:sort select="@order" />
                                                                <B>
                                                                    Step
                                                                    <xsl:value-of select="@order" />
                                                                    :
                                                                </B>
                                                                <br />
                                                                <xsl:value-of select=".//step_desc" />
                                                                <br />
                                                                <B>Expected:</B>
                                                                <xsl:value-of select=".//expected" />
                                                                <br />
                                                            </xsl:for-each>
                                                        </p>
                                                        <p>
                                                            <br />
                                                            <B>
                                                                Entry:
                                                                <br />
                                                            </B>
                                                            <xsl:value-of select="./description//test_script_entry" />
                                                            <br />
                                                        </p>
                                                    </div>
                                                    <a href="#" class="test_case_popup">
                                                        <xsl:attribute name="id">fail_<xsl:value-of
                                                            select="@id" /></xsl:attribute>
                                                        <xsl:value-of select="@id" />
                                                    </a>
                                                </td>
                                                <td>
                                                    <xsl:value-of select="@purpose" />
                                                </td>

                                                <td class="red_rate">
                                                    <xsl:value-of select="@result" />
                                                </td>
                                                <td>
                                                    <xsl:call-template name="br-replace">
                                                        <xsl:with-param name="word"
                                                            select=".//result_info/stdout" />
                                                    </xsl:call-template>
                                                    <xsl:if test=".//result_info/stdout = ''">
                                                        N/A
                                                    </xsl:if>
                                                </td>
                                            </tr>
                                        </xsl:for-each>
                                    </xsl:for-each>
                                </table>
                            </xsl:for-each>
                        </div>
                        <div id="see_block" style="display:none;">
                            <xsl:for-each select="test_definition/suite">
                                <xsl:sort select="@name" />
                                <div id="suite_title">
                                    <h2>
                                        Test Suite:
                                        <xsl:value-of select="@name" />
                                        (Blocked Only)
                                    </h2>
                                    <a>
                                        <xsl:attribute name="name">
                                                                     <xsl:value-of
                                            select="@name" />
                                                                  </xsl:attribute>
                                    </a>
                                </div>
                                <table>
                                    <tr>
                                        <th>Case_ID</th>
                                        <th>Purpose</th>
                                        <th>Result</th>
                                        <th>Stdout</th>
                                    </tr>
                                    <xsl:for-each select=".//set">
                                        <xsl:sort select="@name" />
                                        <tr>
                                            <xsl:choose>
                                                <xsl:when test="@name">
                                                    <td colspan="3">
                                                        <h3>
                                                            Test Set:
                                                            <xsl:value-of select="@name" />
                                                        </h3>
                                                    </td>
                                                    <td colspan="1">
                                                        <h4>
                                                            <a>
                                                                <xsl:attribute name="href"><xsl:value-of
                                                                    select="@set_debug_msg" /></xsl:attribute>
                                                                dlog
                                                            </a>
                                                        </h4>
                                                    </td>
                                                </xsl:when>
                                                <xsl:otherwise>
                                                    <td colspan="4">
                                                        <h3>
                                                            Test Set:
                                                            <xsl:value-of select="@name" />
                                                        </h3>
                                                    </td>
                                                </xsl:otherwise>
                                            </xsl:choose>
                                        </tr>
                                        <xsl:for-each select=".//testcase[@result='BLOCK']">
                                            <xsl:sort select="@id" />
                                            <tr>
                                                <td>
                                                    <div
                                                        style="background-color:#F5DEB3;border:1px solid black;display:none;">
                                                        <xsl:attribute name="id">block_<xsl:value-of
                                                            select="@id" /></xsl:attribute>
                                                        <p>
                                                            <xsl:for-each select="./description/steps//step">
                                                                <xsl:sort select="@order" />
                                                                <B>
                                                                    Step
                                                                    <xsl:value-of select="@order" />
                                                                    :
                                                                </B>
                                                                <br />
                                                                <xsl:value-of select=".//step_desc" />
                                                                <br />
                                                                <B>Expected:</B>
                                                                <xsl:value-of select=".//expected" />
                                                                <br />
                                                            </xsl:for-each>
                                                        </p>
                                                        <p>
                                                            <br />
                                                            <B>
                                                                Entry:
                                                                <br />
                                                            </B>
                                                            <xsl:value-of select="./description//test_script_entry" />
                                                            <br />
                                                        </p>
                                                    </div>
                                                    <a href="#" class="test_case_popup">
                                                        <xsl:attribute name="id">block_<xsl:value-of
                                                            select="@id" /></xsl:attribute>
                                                        <xsl:value-of select="@id" />
                                                    </a>
                                                </td>
                                                <td>
                                                    <xsl:value-of select="@purpose" />
                                                </td>

                                                <td class="orange_rate">
                                                    <xsl:value-of select="@result" />
                                                </td>
                                                <td>
                                                    <xsl:call-template name="br-replace">
                                                        <xsl:with-param name="word"
                                                            select=".//result_info/stdout" />
                                                    </xsl:call-template>
                                                    <xsl:if test=".//result_info/stdout = ''">
                                                        N/A
                                                    </xsl:if>
                                                </td>
                                            </tr>
                                        </xsl:for-each>
                                    </xsl:for-each>
                                </table>
                            </xsl:for-each>
                        </div>
                        <div id="see_na" style="display:none;">
                            <xsl:for-each select="test_definition/suite">
                                <xsl:sort select="@name" />
                                <div id="suite_title">
                                    <h2>
                                        Test Suite:
                                        <xsl:value-of select="@name" />
                                        (Not executed Only)
                                    </h2>
                                    <a>
                                        <xsl:attribute name="name">
                                                                     <xsl:value-of
                                            select="@name" />
                                                                  </xsl:attribute>
                                    </a>
                                </div>
                                <table>
                                    <tr>
                                        <th>Case_ID</th>
                                        <th>Purpose</th>
                                        <th>Result</th>
                                        <th>Stdout</th>
                                    </tr>
                                    <xsl:for-each select=".//set">
                                        <xsl:sort select="@name" />
                                        <tr>
                                            <xsl:choose>
                                                <xsl:when test="@name">
                                                    <td colspan="3">
                                                        <h3>
                                                            Test Set:
                                                            <xsl:value-of select="@name" />
                                                        </h3>
                                                    </td>
                                                    <td colspan="1">
                                                        <h4>
                                                            <a>
                                                                <xsl:attribute name="href"><xsl:value-of
                                                                    select="@set_debug_msg" /></xsl:attribute>
                                                                dlog
                                                            </a>
                                                        </h4>
                                                    </td>
                                                </xsl:when>
                                                <xsl:otherwise>
                                                    <td colspan="4">
                                                        <h3>
                                                            Test Set:
                                                            <xsl:value-of select="@name" />
                                                        </h3>
                                                    </td>
                                                </xsl:otherwise>
                                            </xsl:choose>
                                        </tr>
                                        <xsl:for-each select=".//testcase[@result='N/A']">
                                            <xsl:sort select="@id" />
                                            <tr>
                                                <td>
                                                    <div
                                                        style="background-color:#F5DEB3;border:1px solid black;display:none;">
                                                        <xsl:attribute name="id">na_<xsl:value-of
                                                            select="@id" /></xsl:attribute>
                                                        <p>
                                                            <xsl:for-each select="./description/steps//step">
                                                                <xsl:sort select="@order" />
                                                                <B>
                                                                    Step
                                                                    <xsl:value-of select="@order" />
                                                                    :
                                                                </B>
                                                                <br />
                                                                <xsl:value-of select=".//step_desc" />
                                                                <br />
                                                                <B>Expected:</B>
                                                                <xsl:value-of select=".//expected" />
                                                                <br />
                                                            </xsl:for-each>
                                                        </p>
                                                        <p>
                                                            <br />
                                                            <B>
                                                                Entry:
                                                                <br />
                                                            </B>
                                                            <xsl:value-of select="./description//test_script_entry" />
                                                            <br />
                                                        </p>
                                                    </div>
                                                    <a href="#" class="test_case_popup">
                                                        <xsl:attribute name="id">na_<xsl:value-of
                                                            select="@id" /></xsl:attribute>
                                                        <xsl:value-of select="@id" />
                                                    </a>
                                                </td>
                                                <td>
                                                    <xsl:value-of select="@purpose" />
                                                </td>

                                                <td class="gray_rate">
                                                    <xsl:value-of select="@result" />
                                                </td>
                                                <td>
                                                    <xsl:call-template name="br-replace">
                                                        <xsl:with-param name="word"
                                                            select=".//result_info/stdout" />
                                                    </xsl:call-template>
                                                    <xsl:if test=".//result_info/stdout = ''">
                                                        N/A
                                                    </xsl:if>
                                                </td>
                                            </tr>
                                        </xsl:for-each>
                                    </xsl:for-each>
                                </table>
                            </xsl:for-each>
                        </div>
                    </div>
                </div>
                <div id="goTopBtn">
                    <img border="0" src="./style/back_top.png" />
                </div>
                <script type="text/javascript" src="./style/application.js" />
                <script language="javascript" type="text/javascript">
                    $(document).ready(function(){
                    goTopEx();
                    });
                </script>
            </body>
        </html>
    </xsl:template>
    <xsl:template name="br-replace">
        <xsl:param name="word" />
        <xsl:variable name="cr">
            <xsl:text>\n</xsl:text>
        </xsl:variable>
        <xsl:choose>
            <xsl:when test="contains($word,$cr)">
                <xsl:value-of select="substring-before($word,$cr)" />
                <br />
                <xsl:call-template name="br-replace">
                    <xsl:with-param name="word" select="substring-after($word,$cr)" />
                </xsl:call-template>
            </xsl:when>
            <xsl:otherwise>
                <xsl:value-of select="$word" />
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
</xsl:stylesheet>
