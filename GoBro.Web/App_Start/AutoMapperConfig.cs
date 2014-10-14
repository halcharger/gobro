using AutoMapper;
using GoBro.Core.Commands;
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
                cfg.CreateMap<UploadVideoModel, UploadVideoCommand>();
            });

            Mapper.AssertConfigurationIsValid();
        }

        public static List<T> MapTo<T>(this IEnumerable<object> input)
        {
            return input.Select(Mapper.Map<T>).ToList();
        }

        public static T MapTo<T>(this object input)
        {
            return Mapper.Map<T>(input);
        }
    }
}