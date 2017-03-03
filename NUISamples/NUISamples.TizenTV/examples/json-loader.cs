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
using Dali;

namespace MyExampleApp
{
  class Example
  {
    private Dali.Application _application;
    private Builder _builder;
    private string _jsonFileName;

    public Example(Dali.Application application, string fileName)
    {
      _application = application;
      _jsonFileName = fileName;
      _application.Initialized += Initialize;
    }

    public void Initialize(object source, NUIApplicationInitEventArgs e)
    {
        if( _jsonFileName.Length == 0)
        {
          Console.WriteLine("Please specify JSON file to load");
          return;
        }

        _builder = new Builder ();

        Property.Map constants = new  Property.Map();

        //  In dali-demo we have some JSON files that can be loaded, but they need 3 different macros defining.
        // The JSON folder is typically installed into dali-env/opt/share/com.samsung.dali-demo/res:
        //
        //string demoDirectory = ".../dali-env/opt/share/com.samsung.dali-demo/res";
        //constants.Insert( "DEMO_IMAGE_DIR" ,  new Property.Value( demoDirectory+"/images") );
        //constants.Insert( "DEMO_MODEL_DIR" ,  new Property.Value( demoDirectory+"/models") );
        //constants.Insert( "DEMO_SCRIPT_DIR",  new Property.Value( demoDirectory+"/scripts") );
        constants.Insert( "CONFIG_SCRIPT_LOG_LEVEL",  new Property.Value( "Verbose") );

         _builder.AddConstants( constants );


        Stage stage = Stage.GetCurrent();
        stage.BackgroundColor = Color.White;

        _builder.LoadFromFile( _jsonFileName );

        _builder.AddActors( stage.GetRootLayer() );

    }


    public void MainLoop()
    {
      _application.MainLoop ();
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      string fileName= "";

      if( args.Length > 0)
      {
          fileName = args[0];
      }

      Console.WriteLine("arguments = " + args.Length);
      Example example = new Example(Application.NewApplication(), fileName);
      example.MainLoop ();
    }
  }
}
