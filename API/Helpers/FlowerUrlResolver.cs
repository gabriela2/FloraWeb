using API.Dtos;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Core.Entities;

namespace API.Helpers
{
    public class FlowerUrlResolver : IValueResolver<Flower, FlowerToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public FlowerUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Flower source, FlowerToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)){
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}