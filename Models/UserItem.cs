using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace demo.Models;

public class UserItem
{
        public int user_idx { get; set; }

        public string permit_type { get; set; } = null!;

        public string user_nm { get; set; } = null!;

        public string user_id { get; set; } = null!;

        public string user_hp { get; set; } = null!;

        public string user_email { get; set; } = null!;

        public string app_os { get; set; } = null!;

        public string user_token { get; set; } = null!;

        public string department { get; set; } = null!;

        public string position { get; set; } = null!;

        public string direct_tel { get; set; } = null!;

        public string support_center { get; set; } = null!;

        public int comm_agent_idx { get; set; }

        public string agent_nm { get; set; } = null!;

        public string agent_manager_nm { get; set; } = null!;

        public string main_tel { get; set; } = null!;

        public string agent_type { get; set; } = null!;

        public string another_data { get; set; } = null!;

        // [JsonProperty("index")]
        // [Key]
        // public int USER_IDX { get; set; }

        // [JsonProperty("authority")]
        // public string PERMIT_TYPE { get; set; }

        // [JsonProperty("name")]
        // public string USER_NM { get; set; }

        // [JsonProperty("id")]
        // public string USER_ID { get; set; }

        // [JsonProperty("mobile")]
        // public string USER_HP { get; set; }

        // [JsonProperty("email")]
        // public string USER_EMAIL { get; set; }

        // [JsonProperty("system")]
        // public string APP_OS { get; set; }

        // [JsonProperty("token")]
        // public string USER_TOKEN { get; set; }

        // [JsonProperty("department")]
        // public string DEPARTMENT { get; set; }

        // [JsonProperty("position")]
        // public string POSITION { get; set; }

        // [JsonProperty("homePhone")]
        // public string DIRECT_TEL { get; set; }

        // [JsonProperty("supportCenter")]
        // public string SUPPORT_CENTER { get; set; }

        // [JsonProperty("agentIndex")]
        // public int COMM_AGENT_IDX { get; set; }

        // [JsonProperty("agentName")]
        // public string AGENT_NM { get; set; }

        // [JsonProperty("agentManagerName")]
        // public string AGENT_MANAGER_NM { get; set; }

        // [JsonProperty("agentPhone")]
        // public string MAIN_TEL { get; set; }

        // [JsonProperty("agentType")]
        // public string AGENT_TYPE { get; set; }
}