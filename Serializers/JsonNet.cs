﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializerTests.Serializers
{
    // http://www.newtonsoft.com/json
    public class JsonNet<T> : TestBase<T,JsonSerializer> where T : class
    {
        public JsonNet(Func<int, T> testData)
        {
            base.CreateNTestData = testData;
            FormatterFactory = () => new JsonSerializer();
        }

        protected override void Serialize(T obj, Stream stream)
        {
            var text = new StreamWriter(stream);
            Formatter.Serialize(text, obj);
            text.Flush();
        }

        protected override T Deserialize(Stream stream)
        {
            TextReader text = new StreamReader(stream);
            return (T)Formatter.Deserialize(text, typeof(T));
        }
    }
}
