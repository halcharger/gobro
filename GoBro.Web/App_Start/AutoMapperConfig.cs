﻿using AutoMapper;
using GoBro.Core.Commands;
using GoBro.Core.Models;
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
                cfg.CreateMap<Video, VideoThumbnailViewModel>()
                    .ForMember(dest => dest.CanManage, opt => opt.Ignore());
                cfg.CreateMap<UploadVideoBindingModel, UploadVideoCommand>()
                    .ForMember(dest => dest.Username, opt => opt.Ignore());
                cfg.CreateMap<Video, VideoViewModel>();
            });

            Mapper.AssertConfigurationIsValid();
        }

        public static List<T> MapTo<T>(this IEnumerable<object> input, Action<T> postMappingRoutine = null)
        {
            var results = input.Select(Mapper.Map<T>).ToList();

            if (postMappingRoutine == null)
                return results;

            results.ForEach(postMappingRoutine);
            return results;
        }

        public static T MapTo<T>(this object input)
        {
            return Mapper.Map<T>(input);
        }
    }
}