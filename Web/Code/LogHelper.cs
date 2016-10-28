using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using log4net;
public class LogHelper
{
    public static void LogException(ILog log, Exception baseException)
    {
        if (log.IsErrorEnabled)
        {
            //User currentUser = AppHelper.CurrentUser;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine("异常类型: " + baseException.GetType().ToString());
            builder.AppendLine("异常内容: " + baseException.Message);
            builder.AppendLine("异常页面：" + HttpContext.Current.Request.Url);
            //builder.AppendLine("当前版本：" + string.Format("Release:{0} Build:{1}", VersionManager.Release, VersionManager.Build));
            builder.AppendLine("浏 览 器：" + HttpContext.Current.Request.Browser.Type);
            builder.AppendLine("操作系统：" + Environment.OSVersion);
            //builder.AppendLine("操作人员：" + string.Format("{0}（Id：{1}；邮件：{2}；电话：{3}）", currentUser.Name, currentUser.Id, currentUser.Mail, currentUser.Mobile));
            builder.AppendLine("堆栈跟踪：" + Environment.NewLine + baseException.StackTrace);

            DbEntityValidationException dbEntityValidationException = baseException as DbEntityValidationException;
            if (dbEntityValidationException != null)
            {
                builder.AppendLine($"DbEntityValidationException明细：有{dbEntityValidationException.EntityValidationErrors.Count()}个实体验证失败：");
                foreach (var entityValidationError in dbEntityValidationException.EntityValidationErrors)
                {
                    object entity = entityValidationError.Entry.Entity;
                    builder.AppendLine($"类型：{entity.GetType()}，实体：{entity}，有{entityValidationError.ValidationErrors.Count()}个字段验证失败：");
                    foreach (var validationError in entityValidationError.ValidationErrors)
                    {
                        builder.AppendLine($"{validationError.PropertyName}：{validationError.ErrorMessage}");
                    }
                }
            }

            builder.AppendLine();
            log.Error(builder.ToString());
        }
    }
}
