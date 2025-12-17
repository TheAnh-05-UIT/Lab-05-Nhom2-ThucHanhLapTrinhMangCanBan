using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05_Lab05
{

    public class Pagination
    {
        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
    public class DishResponse
    {
        [JsonProperty("data")] 
        public List<Dish> Data { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
    public class Dish
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ten_mon_an")]
        public string Name { get; set; }

        [JsonProperty("gia")]
        public decimal Price { get; set; }

        [JsonProperty("dia_chi")]
        public string Address { get; set; }

        [JsonProperty("hinh_anh")]
        public string Image { get; set; }

        [JsonProperty("mo_ta")]
        public string Description { get; set; }

        [JsonProperty("nguoi_dong_gop")]
        public string Contributor { get; set; }
    }
}