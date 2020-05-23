using System;
using System.Collections.Generic;
using System.Text;

namespace FlagsGame.Core.IOUtils
{

	//Library developed by the Laboratorio de Geomática de la Universidad de Alicante (https://iig.ua.es/es/geomatica/)
	//Copyright (C) 2011 Laboratorio de Geomática de la Universidad de Alicante
	//email: labsig.iug@ua.es

	//This library is free software; you can redistribute it and/or modify  
	//it  under the terms of the GNU Lesser General Public License as 	  
	//published by the Free Software Foundation, either version 3 of 	   
	//the License, or (at your option) any later version.		   
	//                                                                      
	//This library is distributed in the hope that it will be useful, but   
	//WITHOUT ANY WARRANTY; without even the implied warranty of            
	//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU     
	//Lesser General Public License for more details.                       
	//                                                                         
	//You should have received a copy of the GNU Lesser General Public      
	//License along with this library; if not, see         		   
	//<http://www.gnu.org/licenses/>.		

	using System;
	using System.Collections.Generic;
	using System.IO;

	namespace Core.IOUtils
	{
		/// <summary>
		/// Description of SimpleCfgReader.
		/// </summary>
		public class SimpleCfgReader
		{
			readonly char[] ASSIGNMENT = { '=' };
			Dictionary<string, string> _parameters = new Dictionary<string, string>();

			public SimpleCfgReader(string filePath)
			{
				using (StreamReader reader = File.OpenText(filePath))
				{
					while (!reader.EndOfStream)
					{
						string line = reader.ReadLine();
						string[] parameter = line.Split(ASSIGNMENT);
						if (parameter.Length == 2)
						{
							_parameters.Add(parameter[0], parameter[1]);
						}
					}
				}
			}


			public string GetString(string key)
			{
				if (_parameters.ContainsKey(key))
				{
					return _parameters[key];
				}
				return string.Empty;
			}
		}
	}

}
