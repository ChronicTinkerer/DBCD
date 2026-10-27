#pragma warning disable CS0169

using System.Runtime.InteropServices;

namespace DBCD.IO.Common
{
    public enum RecordState : byte
    {
        NotSet,
        Valid,
        Delete,
        Invalid,
        NotPublic
    }

    public interface IHotfixEntry
    {
        int PushId { get; }
        int DataSize { get; }
        uint TableHash { get; }
        int RecordId { get; }
        bool IsValid { get; }
        RecordState State { get; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct HotfixEntryV1 : IHotfixEntry
    {
        public int PushId { get; }
        public int DataSize { get; }
        public uint TableHash { get; }
        public int RecordId { get; }
        public bool IsValid { get; }
        private readonly byte pad1, pad2, pad3;

        public RecordState State => IsValid ? RecordState.Valid : RecordState.Invalid;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct HotfixEntryV2 : IHotfixEntry
    {
        public uint Version { get; }
        public int PushId { get; }
        public int DataSize { get; }
        public uint TableHash { get; }
        public int RecordId { get; }
        public bool IsValid { get; }
        private readonly byte pad1, pad2, pad3;

        public RecordState State => IsValid ? RecordState.Valid : RecordState.Invalid;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct HotfixEntryV7 : IHotfixEntry
    {
        public int PushId { get; }
        public uint TableHash { get; }
        public int RecordId { get; }
        public int DataSize { get; }
        private readonly byte op, pad1, pad2, pad3;

        public bool IsValid => op == 1;
        public RecordState State => (RecordState)op;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct HotfixEntryV8 : IHotfixEntry
    {
        public int PushId { get; }
        public int UniqueId { get; }
        public uint TableHash { get; }
        public int RecordId { get; }
        public int DataSize { get; }
        private readonly byte op, pad1, pad2, pad3;

        public bool IsValid => op == 1;
        public RecordState State => (RecordState)op;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct HotfixEntryV9 : IHotfixEntry
    {
        public int RegionId { get; }
        public int PushId { get; }
        public int UniqueId { get; }
        public uint TableHash { get; }
        public int RecordId { get; }
        public int DataSize { get; }
        private readonly byte op, pad1, pad2, pad3;

        public bool IsValid => op == 1;
        public RecordState State => (RecordState)op;
    }
}
