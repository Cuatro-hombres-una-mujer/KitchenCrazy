using System;
using System.Collections.Generic;

namespace Helper
{
    public class Pagination<T>
    {
        private const int SlotPaginateDefault = 10;

        private readonly int _slots;
        private readonly List<T> _entities;

        public Pagination(List<T> entities, int slots)
        {
            _entities = entities;
            _slots = slots;
        }

        public List<T> Search(int page)
        {
            int result = (page - 1) * _slots;

            if (result > _entities.Count)
            {
                return new List<T>();
            }

            int limit = Math.Min(result + _slots, _entities.Count);
            return _entities.GetRange(result, limit);
        }

        public bool Exists(int page)
        {
            var result = (page - 1) * _slots;
            return _entities.Count >= result;
        }

        public static List<T> Paginate<T>(List<T> entities, int page)
        {
            return Paginate(entities, page, SlotPaginateDefault);
        }

        public static List<T> Paginate<T>(List<T> entities, int page, int slots)
        {
            Pagination<T> pagination = Of(entities, slots);
            return pagination.Search(page);
        }

        public static Pagination<T> Of<T>(List<T> entities, int slots)
        {
            return new Pagination<T>(entities, slots);
        }
    }
}