﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp {
    public class Product {
        //商品コード
        public int Code{get; set;}  //自動実装プロパティ(P23)
        //商品名
        public string Name { get; set;}
        //商品価格(税抜き)
        public int Price { get; set;}

        public Product(int code,string Name,int Price) { 
            this.Code = code;
            this.Name = Name;
            this.Price = Price;
        }

        //消費税を求める（消費税率10%)
        public int GetTax() {
            return (int)(Price * 0.1);
        }
        //税込価格を求める
        public int GetPriceIncludingTax() {
            return Price + GetTax();
        }
    }
}
