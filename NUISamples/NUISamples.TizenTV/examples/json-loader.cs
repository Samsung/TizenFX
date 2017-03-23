/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using Tizen.NUI;

namespace JsonLoaderTest
{
  class Example : NUIApplication
  {
    private Builder _builder;
    private string _jsonFileName;

    public Example() : base()
    {
    }

    public Example(string stylesheet) : base(stylesheet)
    {
       _jsonFileName = stylesheet;
    }

    public Example(string stylesheet, WindowMode windowMode) : base(stylesheet, windowMode)
    {
    }

    protected override void OnCreate()
    {
        base.OnCreate();
        Initialize();
    }

    public void Initialize()
    {
        if( _jsonFileName.Length == 0)
        {
          Console.WriteLine("Please specify JSON file to load");
          return;
        }

        _builder = new Builder ();

        PropertyMap constants = new  PropertyMap();

        //  In dali-demo we have some JSON files that can be loaded, but they need 3 different macros defining.
        // The JSON folder is typically installed into dali-env/opt/share/com.samsung.dali-demo/res:
        //
        //string demoDirectory = ".../dali-env/opt/share/com.samsung.dali-demo/res";
        //constants.Insert( "DEMO_IMAGE_DIR" ,  new PropertyValue( demoDirectory+"/images") );
        //constants.Insert( "DEMO_MODEL_DIR" ,  new PropertyValue( demoDirectory+"/models") );
        //constants.Insert( "DEMO_SCRIPT_DIR",  new PropertyValue( demoDirectory+"/scripts") );
        constants.Insert( "CONFIG_SCRIPT_LOG_LEVEL",  new PropertyValue( "Verbose") );

         _builder.AddConstants( constants );


        Stage stage = Stage.Instance;
        stage.BackgroundColor = Color.White;

        _builder.LoadFromFile( _jsonFileName );

        _builder.AddActors( stage.GetDefaultLayer() );

    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void _Main(string[] args)
    {
      string fileName= "";

      if( args.Length > 0)
      {
          fileName = args[0];
      }

      Console.WriteLine("arguments = " + args.Length);
      Example example = new Example(fileName);
      example.Run(args);
    }
  }
}
