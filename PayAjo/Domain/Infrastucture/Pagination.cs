using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture
{
    public class Pagination<T>
    {
        public long PageIndex { get; private set; }
        public long SequenceLength { get; private set; }
        public T[] Page { get; private set; }
        public long PageCount { get; private set; }
        public long PageSize { get; private set; }

        public Pagination(T[] page, long sequenceLength, int pageSize = 1, int pageIndex = 0)
        {
            if (page == null) throw new Exception("invalid page");

            PageIndex = pageIndex;
            SequenceLength = Math.Abs(sequenceLength);
            Page = page;
            PageSize = pageSize == 0 && Page.Length == 0 ? 1 :
                       Page.Length == 0 ? 1 :
                       pageSize == 0 ? Page.Length :
                       Math.Abs(pageSize);

            PageCount = SequenceLength / PageSize + (SequenceLength % PageSize > 0 ? 1 : 0);
        }

        public Pagination()
        : this(new T[0], 0)
        { }

        /// <summary>
        /// Returns an array containing page indexes for pages immediately adjecent to the current page.
        /// The span indicates how many pages indexes to each side of the current page should be returned
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        public long[] AdjacentIndexes(int span)
        {
            if (span < 0) throw new Exception("invalid span: " + span);

            var fullspan = (span * 2) + 1;
            long start = 0,
                 count = 0;

            if (fullspan >= PageCount) count = PageCount;

            else
            {
                start = PageIndex - span;
                count = fullspan;

                if (start < 0) start = 0;
                if ((PageIndex + span) >= PageCount) start = PageCount - fullspan;
            }

            return GenerateSequence(count, _indx => _indx + start).ToArray();
        }

        private IEnumerable<long> GenerateSequence(long count, Func<long, long> generator)
        {
            for (long cnt = 0; cnt < count; cnt++)
                yield return generator.Invoke(cnt);
        }
    }
}
