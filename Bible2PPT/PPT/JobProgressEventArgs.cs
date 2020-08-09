using System;
using Bible2PPT.Bibles;

namespace Bible2PPT.PPT
{
    class JobProgressEventArgs : EventArgs
    {
        public Job Job { get; }
        public Chapter CurrentChapter { get; }

        public int QueriesDone { get; }
        public int Queries { get; }
        public int ChaptersDone { get; }
        public int Chapters { get; }

        public double Progress => (Chapters == 0)
            ? (double)QueriesDone / Queries
            : (double)Math.Min(QueriesDone + 1, Queries) / Queries * ChaptersDone / Chapters;

        public JobProgressEventArgs(Job job, Chapter currentChapter, int queriesDone, int queries, int chaptersDone, int chapters)
        {
            Job = job;
            CurrentChapter = currentChapter;
            QueriesDone = queriesDone;
            Queries = queries;
            ChaptersDone = chaptersDone;
            Chapters = chapters;
        }
    }
}
