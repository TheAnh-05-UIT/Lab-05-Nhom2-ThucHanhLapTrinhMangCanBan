using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05_Lab05
{
    public static class AuthToken
    {
        public static string TokenType { get; set; }  // Tùy chọn, nếu cần lưu token_type (ví dụ: "Bearer")
        public static string AccessToken { get; set; }
    }
}
