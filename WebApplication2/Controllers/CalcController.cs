using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CalcController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manual()
        {
            if (Request.Method == "POST")
            {
                string valFString = Request.Form["valFirst"];
                string valSString = Request.Form["valSecond"];
                string ope = Request.Form["op"];
                int valF = Int32.Parse(valFString);
                int valS = Int32.Parse(valSString);
                if ((valS == 0) && (ope == "/")) { return Redirect("~/Calc/Error"); };
                string mess;
                int re;
                switch (ope)
                {
                    case "+":
                        re = valF + valS;
                        mess = $"{valF} {ope} {valS} = {re}";
                        ViewData["Message"] = mess;
                        return View("ResultManual");
                    case "-":
                        re = valF - valS;
                        mess = $"{valF} {ope} {valS} = {re}";
                        ViewData["Message"] = mess;
                        return View("ResultManual");
                    case "*":
                        re = valF * valS;
                        mess = $"{valF} {ope} {valS} = {re}";
                        ViewData["Message"] = mess;
                        return View("ResultManual");
                    case "/":
                        re = valF / valS;
                        mess = $"{valF} {ope} {valS} = {re}";
                        ViewData["Message"] = mess;
                        return View("ResultManual");
                }

                return View("ResultManual");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ManualWithSeperateHandlers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ManualWithSeperateHandlers(int valFirst, string op, int valSecond)
        {
            if ((valSecond == 0) && (op == "/")) { return Redirect("~/Calc/Error"); };
            string mes;
            int r;
            switch (op)
            {
                case "+":
                    r = valFirst + valSecond;
                    mes = $"{valFirst} {op} {valSecond} = {r}";
                    ViewData["Message"] = mes;
                    return View("ResultManual");
                case "-":
                    r = valFirst - valSecond;
                    mes = $"{valFirst} {op} {valSecond} = {r}";
                    ViewData["Message"] = mes;
                    return View("ResultManual");
                case "*":
                    r = valFirst * valSecond;
                    mes = $"{valFirst} {op} {valSecond} = {r}";
                    ViewData["Message"] = mes;
                    return View("ResultManual");
                case "/":
                    r = valFirst / valSecond;
                    mes = $"{valFirst} {op} {valSecond} = {r}";
                    ViewData["Message"] = mes;
                    return View("ResultManual");
            }

            return View("ResultManual");
        }

        [HttpGet]
        public IActionResult ModelBindingInParameters()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelBindingInParameters(int valueFirst, string operation, int valueSecond)
        {
            if ((valueSecond == 0) && (operation=="/")) { return Redirect("~/Calc/Error"); };
            var model = new Numbers()
            {
                ValueFirst = valueFirst,
                ValueSecond = valueSecond,
                Operation = operation
            };
            switch (operation)
            {
                case "+":
                    ViewBag.res = valueFirst + valueSecond;
                    return View("Result");
                case "-":
                    ViewBag.res = valueFirst - valueSecond;
                    return View("Result");
                case "*":
                    ViewBag.res = valueFirst * valueSecond;
                    return View("Result");
                case "/":
                    ViewBag.res = valueFirst / valueSecond;
                    return View("Result");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ModelBindingInSeperateModel()
        {
            return View(new Numbers());
        }

        [HttpPost]
        public IActionResult ModelBindingInSeperateModel(Numbers model)
        {
            if ((model.ValueSecond == 0) && (model.Operation == "/")) { return Redirect("~/Calc/Error"); };
            switch (model.Operation)
            {
                case "+":
                    ViewBag.res = model.ValueFirst + model.ValueSecond;
                    return View("Result");
                case "-":
                    ViewBag.res = model.ValueFirst - model.ValueSecond;
                    return View("Result");
                case "*":
                    ViewBag.res = model.ValueFirst * model.ValueSecond;
                    return View("Result");
                case "/":
                    ViewBag.res = model.ValueFirst / model.ValueSecond;
                    return View("Result");
            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
