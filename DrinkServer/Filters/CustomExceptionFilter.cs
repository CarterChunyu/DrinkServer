using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DrinkServer.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomExceptionFilter(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }
        /// <summary>
        /// 發生異常進入
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)//如果異常沒有處理
            {
                //導向到其他葉面
                var result = new ViewResult { ViewName = "../Home/Index" };

                result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);

                //帶錯誤資料過去
                result.ViewData.Add("Exception", context.Exception);//傳遞資料

                //存錯誤資料到DB

                context.Result = result;


                context.ExceptionHandled = true;//異常已處理 錯誤攔截

            }
        }


    }
}
