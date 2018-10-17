﻿using Doan_25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_25.Model
{
    public class _Paging
    {
        public PageInfo<tblProduct> _getPaging(int _pagesize, int _pageCurrent, IList<tblProduct> listProduct)
        {
            var count = listProduct.Count;
            var products = (from p in listProduct orderby p.ProductID select p).Skip((_pageCurrent - 1) * _pagesize).Take(_pagesize).ToList();
            var pageinfor = new PageInfo<tblProduct>
            {
                CurrentPage = _pageCurrent,
                ListItem = products,
                pageSize = _pagesize,
                pageCount = count / _pagesize + 1
            };
            return pageinfor;
        }

        public PageInfo<tblCategory> _getPaging(int _pagesize, int _pageCurrent, IList<tblCategory> listProduct)
        {
            var count = listProduct.Count;
            var products = (from p in listProduct orderby p.CategoryID select p).Skip((_pageCurrent - 1) * _pagesize).Take(_pagesize).ToList();
            var pageinfor = new PageInfo<tblCategory>
            {
                CurrentPage = _pageCurrent,
                ListItem = products,
                pageSize = _pagesize,
                pageCount = count / _pagesize + 1
            };
            return pageinfor;
        }
        public PageInfo<tblCustomer> _getPagingUser(int _pagesize, int _pageCurrent, IList<tblCustomer> listUser)
        {
            var count = listUser.Count;
            var user = (from p in listUser orderby p.CustomerID select p).Skip((_pageCurrent - 1) * _pagesize).Take(_pagesize).ToList();
            var pageinfor = new PageInfo<tblCustomer>
            {
                CurrentPage = _pageCurrent,
                ListItem = user,
                pageSize = _pagesize,
                pageCount = count / _pagesize + 1
            };
            return pageinfor;

        }
    }
}