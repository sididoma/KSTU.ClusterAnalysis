using KSTU.ClusterAnalysis.BLL.Interfaces;
using KSTU.Common.DistanceCheckers;
using KSTU.Common.Helpers;
using KSTU.Common.Interfaces;
using KSTU.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSTU.Web.Controllers
{
    public class KMeansController : Controller
    {
        private readonly IKMeans _kMeans;
        private readonly IFileService _fileService;

        public KMeansController(IKMeans kMeans, IFileService fileService)
        {
            _kMeans = kMeans;
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

        [HttpPost]
        public IActionResult ShowResult(KMeansCreateVM model)
        {
            var data = _fileService.GetData(model.UploadFile, model.DataType);
            IDistance distance = DistanceFactory.GetDistance(model.DistanceType);
            var result = _kMeans.Clustering(data, distance, model.ClustersCount);
            ViewBag.Centroids = result.Centroid;
            return View(result.Result);
        }
    }
}