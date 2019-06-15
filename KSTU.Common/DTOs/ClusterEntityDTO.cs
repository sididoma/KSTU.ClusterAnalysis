using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace KSTU.Common.DTOs
{
    [Serializable]
    public class ClusterEntityDTO : BaseEntity
    {
        public string Name { get; set; }
        public int CentroidId { get; set; } = -1;
        public int ClustersCount { get; set; } = 0;
        public List<Interest> Interests { get; set; }
        public List<ClusterEntityDTO> Children { get; set; }
        public List<ClusterEntityDTO> STD { get; set; }

        public List<ClusterEntityDTO> ToList()
        {
            var list = new List<ClusterEntityDTO>();
            list.Add(this);
            return list;
        }

        public ClusterEntityDTO(ClusterEntityDTO dTO)
        {
            Name = dTO.Name;
            CentroidId = dTO.CentroidId;
            ClustersCount = dTO.ClustersCount;
            Interests = new List<Interest>(dTO.Interests);
            Children = dTO.Children == null ? null : new List<ClusterEntityDTO>(dTO.Children);
        }
        public ClusterEntityDTO()
        {

        }
        public object Shallowcopy()
        {
            return this.MemberwiseClone();
        }
    }

    public static class CloneObjectExtension
    {
        /// <summary>
        /// Clones a object via shallow copy
        /// </summary>
        /// <typeparam name="T">Object Type to Clone</typeparam>
        /// <param name="obj">Object to Clone</param>
        /// <returns>New Object reference</returns>
        public static T CloneObject<T>(this T obj) where T : class
        {
            if (obj == null) return null;
            System.Reflection.MethodInfo inst = obj.GetType().GetMethod("MemberwiseClone",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (inst != null)
                return (T)inst.Invoke(obj, null);
            else
                return null;
        }
        public static T CloneObjectSerializable<T>(this T obj) where T : class
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            ms.Position = 0;
            object result = bf.Deserialize(ms);
            ms.Close();
            return (T)result;
        }
    }

}
