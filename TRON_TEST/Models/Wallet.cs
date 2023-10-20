using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRON_TEST.Models
{
    public class Key
    {
        public string address { get; set; }
        public int weight { get; set; }
    }

    public class OwnerPermission
    {
        public List<Key> keys { get; set; }
        public int threshold { get; set; }
        public string permission_name { get; set; }
    }

    public class AccountResource
    {
        public bool energy_window_optimized { get; set; }
        public long energy_window_size { get; set; }
    }

    public class ActivePermission
    {
        public string operations { get; set; }
        public List<Key> keys { get; set; }
        public int threshold { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public string permission_name { get; set; }
    }

    public class Frozen
    {
        public long amount { get; set; }
        public string type { get; set; }
    }

    public class Trc20
    {
        public Dictionary<string,string> TR7NHqjeKQxGTCi8q8ZY4pL8otSzgjLj6t { get; set; }
    }

    public class Vote
    {
        public string vote_address { get; set; }
        public int vote_count { get; set; }
    }

    public class Data
    {
        public OwnerPermission owner_permission { get; set; }
        public AccountResource account_resource { get; set; }
        public List<ActivePermission> active_permission { get; set; }
        public string address { get; set; }
        public long create_time { get; set; }
        public long latest_opration_time { get; set; }
        public int free_net_usage { get; set; }
        public List<Frozen> frozenV2 { get; set; }
        public int balance { get; set; }
        public Trc20 trc20 { get; set; }
        public long latest_consume_free_time { get; set; }
        public List<Vote> votes { get; set; }
        public long net_window_size { get; set; }
        public bool net_window_optimized { get; set; }
    }

    public class Meta
    {
        public long at { get; set; }
        public int page_size { get; set; }
    }

    public class Root
    {
        public List<Data> data { get; set; }
        public bool success { get; set; }
        public Meta meta { get; set; }
    }
}
