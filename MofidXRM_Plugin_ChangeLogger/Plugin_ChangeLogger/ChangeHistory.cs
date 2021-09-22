using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofidXRM_Plugin_ChangeLogger.Plugin_ChangeLogger
{
    public class ChangeHistory
    {
        public string ms_name { get; set; }
        public string ms_recordid { get; set; }
        public string ms_attributename { get; set; }
        public DateTime ms_date { get; set; }
        public OptionSetValue ms_sdkmessagetypecode { get; set; }
        public EntityReference ms_userid { get; set; }
        public string ms_oldvalue { get; set; }
        public string ms_oldname { get; set; }
        public string ms_newvalue { get; set; }
        public string ms_newname { get; set; }

        public Guid Create(IOrganizationService service)
        {
            if (this.ms_oldvalue != this.ms_newvalue)
            {
                Entity changeHistoryEntity = new Entity("ms_changehistory");
                changeHistoryEntity["ms_recordid"] = this.ms_recordid;
                changeHistoryEntity["ms_name"] = this.ms_name;
                changeHistoryEntity["ms_sdkmessagetypecode"] = this.ms_sdkmessagetypecode;
                changeHistoryEntity["ms_date"] = this.ms_date;
                changeHistoryEntity["ms_userid"] = this.ms_userid;
                changeHistoryEntity["ms_newvalue"] = this.ms_newvalue;
                changeHistoryEntity["ms_newname"] = this.ms_newname;
                changeHistoryEntity["ms_oldvalue"] = this.ms_oldvalue;
                changeHistoryEntity["ms_oldname"] = this.ms_oldname;
                changeHistoryEntity["ms_attributename"] = this.ms_attributename;

                return service.Create(changeHistoryEntity);
            }
            return Guid.Empty;
        }
    }
}
