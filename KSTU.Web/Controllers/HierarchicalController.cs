using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using KSTU.ClusterAnalysis.BLL.Interfaces;
using KSTU.Common.ClusterDistanceCheckers;
using KSTU.Common.DistanceCheckers;
using KSTU.Common.Interfaces;
using KSTU.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KSTU.Web.Controllers
{
    public class HierarchicalController : Controller
    {
        private readonly IHierarchical _service;
        private readonly IFileService _fileService;

        public HierarchicalController(IHierarchical service, IFileService fileService)
        {
            _service = service;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }

        public IActionResult ShowResult(HierarchicalCreateVM model)
        {
            var data = _fileService.GetData(model.UploadFile, model.DataType);
            IDistance distance = DistanceFactory.GetDistance(model.DistanceType);
            IClusterDistance clusterDistance = ClusterDistanceFactory.GetClusterDistance(model.ClusterUnionType);
            var result = _service.Clustering(data, distance, clusterDistance, model.CountOfUnionsInStep);
            return View(result);
        }

    }
}