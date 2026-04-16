using AutoMapper;
using DatabaseMastery.TransportMongoDb.Dtos.OfferDtos;
using DatabaseMastery.TransportMongoDb.Entities;
using DatabaseMastery.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DatabaseMastery.TransportMongoDb.Services.OfferServices
{
    public class OfferService : IOfferService
    {
        private readonly IMongoCollection<Offer> _offerCollection;
        private readonly IMapper _mapper;

        public OfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _offerCollection = database.GetCollection<Offer>(_databaseSettings.OfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOfferAsync(CreateOfferDto createOfferDto)
        {
            var values = _mapper.Map<Offer>(createOfferDto);
            await _offerCollection.InsertOneAsync(values);
        }

        public async Task DeleteOfferAsync(string id)
        {
            await _offerCollection.DeleteOneAsync(x => x.OfferId == id);
        }

        public async Task<List<ResultOfferDto>> GetAllOfferAsync()
        {
            var values = await _offerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDto>>(values);
        }

        public async Task<GetOfferByIdDto> GetOfferByIdAsync(string id)
        {
            var values = await _offerCollection.Find(x => x.OfferId == id).FirstOrDefaultAsync();
          return  _mapper.Map<GetOfferByIdDto>(values);
        }

        public async Task UpdateOfferAsync(UpdateOfferDto updateOfferDto)
        {
            var values = _mapper.Map<Offer>(updateOfferDto);
            await _offerCollection.FindOneAndReplaceAsync(x => x.OfferId == updateOfferDto.OfferId, values);
        }
    }
}
