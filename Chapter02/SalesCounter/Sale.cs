﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCounter {
    public class Sale {
        //店舗名
        public String ShopName { get; set; }
        //商品カテゴリ
        public String ProductCategory { get; set; }
        //売上高
        public int Amount { get; set; }
    }
}
