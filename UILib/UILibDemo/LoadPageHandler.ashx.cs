using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UILibDemo
{
    /// <summary>
    /// LoadPageHandler 的摘要说明
    /// </summary>
    public class LoadPageHandler : IHttpHandler
    {
        int pageIndex = 0;
        int pageRows = 20;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.Params["pageIndex"] != null)
            {
               int.TryParse(context.Request.Params["pageIndex"].ToString(), out pageIndex);
            }
            if (context.Request.Params["pageRows"] != null)
            {
                int.TryParse(context.Request.Params["pageRows"].ToString(), out pageRows);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < pageRows; i++)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>王小二</td><td>30</td><td>wang.xiaoer@163.com</td></tr>", (pageIndex * pageRows)+i);
            }
            context.Response.Write(sb.ToString());
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}