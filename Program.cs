/*
 * Created by SharpDevelop.
 * User: Max
 * Date: 6/21/2016
 * Time: 1:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Data;
using System.Collections.Generic;


namespace csv2xml
{
	class Program
	{
		public static void Main(string[] args)
		{
						
			try
			{
				if(args[0].Equals(null))
					Console.Write("opopop...it`s impossible! realy, you must not to see this");
			}
			
			catch (Exception e)
	        {
	            //Console.WriteLine("{0} Exception caught.", e);
	            Console.Write("Ooops...  Seems like you didn`t put a parameter to program\n\n" +
				              "(drag input file on this .exe or  put input-file path as a parameter\nGood luck!\n\n )");
	        }
				
			
			
			var lines = File.ReadAllLines(args[0]);
			
			
			if (lines == null)
				throw new FileNotFoundException();
			string [] headers = lines[0].Split(',');
			
			XmlWriterSettings settings = new XmlWriterSettings( );
			settings.Indent = true;
			settings.Encoding = new UTF8Encoding(false);
			using (XmlWriter writer = XmlWriter.Create(args[0]+".xml",settings))//Console.Out, settings))
			{
				
				writer.WriteStartElement("RECORDS");
				for (Int32 li = 0; li < lines.Length; li++)
				{
					if (li != 0) 
					{
						writer.WriteStartElement("RECORD");
								writer.WriteAttributeString("id", (li).ToString());
								string[] value =lines[li].Split(',');
						for (Int32 col = 0; col < headers.Length; col++)
						{
							
									writer.WriteStartElement("FIELD");
										writer.WriteAttributeString("name", headers[col]);
										writer.WriteAttributeString("value", value[col] );
									writer.WriteEndElement( );
							
							
						}
						writer.WriteEndElement( );
						
					}
				}
				writer.WriteEndElement( );
				
			}
			

			Console.WriteLine("Done . . . ");
			Console.WriteLine("XML is next to the original(input) file");
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}