using AutoMapper;
using GoBro.Core.Model;
using GoBro.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoBro.Web
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Video, VideoThumbnailViewModel>();
            });

            Mapper.AssertConfigurationIsValid();
        }

        public static List<T> MapTo<T>(this IEnumerable<object> input)
        {
            return input.Select(Mapper.Map<T>).ToList();
        }
    }
}