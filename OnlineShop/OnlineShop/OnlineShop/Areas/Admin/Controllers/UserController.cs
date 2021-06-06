﻿using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using OnlineShop.Common;
using PagedList;
namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page =1, int page_zise =1)
        {
            var dao = new UserDao();
            var list = dao.GetListUser(page, page_zise);
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
      public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var pass = Encryptor.MD5Hash(user.Password);
                user.Password = pass;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index","Home");
                }else if(id == 0)
                {
                ModelState.AddModelError("", "User is exist!");
                 }
                else
                {
                    ModelState.AddModelError("", "Add new user failed!");
                }
            }
            return View();
        }
    }
}