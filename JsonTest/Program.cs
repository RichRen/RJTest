using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string recommendStr = @"{""errcode"":""0"",""errmsg"":""ok""}";

            var recommendsObj = JsonConvert.DeserializeAnonymousType(recommendStr, new { errcode = 0, errmsg = string.Empty });

            string ss = "";
            string str = "{ID:'1',Name:'aaa',Details:[{ID:'111',Value:'1111111'}]}";

            var obj11 = JsonConvert.DeserializeAnonymousType(str, new { ID = 0, Name = string.Empty, Details = new JArray() });

            str = "[{ID:'1',Name:'aaa',Details:[{ID:'111',Value:'1111111'}]},{ID:'2',Name:'bbb',Details:[{ID:'222',Value:'22222222'}]}]";

            dynamic tok = JsonConvert.DeserializeObject(str);
            foreach (JObject item in tok)
            {
                var id = item["ID"];
                var name = item["Name"];
                foreach (var item2 in item.Properties())
                {
                    var name1 = item2.Name;
                    var v = item2.Value.ToString();
                }
            }

            JArray jAry = (JArray)JsonConvert.DeserializeObject(str);
            var ddd = jAry.ToString();
            for (int i = 0; i < jAry.Count; i++)
            {
                JObject obj = (JObject)jAry[i];
                ss += "ID：" + obj["ID"].ToString() + "\r\n";
                ss += "Name：" + obj["Name"].ToString() + "\r\n";
                JArray json = (JArray)obj["Details"];
                ss += "Detail：\r\n--------\r\n";
                for (int j = 0; j < json.Count; j++)
                {
                    JObject jsonobj = (JObject)json[j];
                    ss += "ID：" + jsonobj["ID"].ToString() + "\r\n";
                    ss += "Value：" + jsonobj["Value"].ToString() + "\r\n";
                    //var age = jsonobj["Value"].Value();
                }
                ss += "--------\r\n\r\n";
            }


            //Json字符串

            JObject sssj = new JObject( //创建JSON对象
        new JProperty( //创建JSON属性
                "Name", //属性名称（在这里是产品类别名称）
                new JArray(new List<string>() { "1", "2", "3" })//属性的值（在这里是该类别下的所有产品名称）

            ));

        }
    }
}
