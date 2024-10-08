﻿using MultiShop.Catalog.Dtos.FeatureDtos;

namespace MultiShop.Catalog.Services.FeatureService
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeaturesAsync();
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);

        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);

        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
    }
}
