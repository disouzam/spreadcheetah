//HintName: MyNamespace.MyGenRowContext.g.cs
// <auto-generated />
#nullable enable
using SpreadCheetah;
using SpreadCheetah.SourceGeneration;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyNamespace
{
    public partial class MyGenRowContext
    {
        private static MyGenRowContext? _default;
        public static MyGenRowContext Default => _default ??= new MyGenRowContext();

        public MyGenRowContext()
        {
        }

        private WorksheetRowTypeInfo<SpreadCheetah.SourceGenerator.SnapshotTest.Models.RecordClassWithSingleProperty>? _RecordClassWithSingleProperty;
        public WorksheetRowTypeInfo<SpreadCheetah.SourceGenerator.SnapshotTest.Models.RecordClassWithSingleProperty> RecordClassWithSingleProperty => _RecordClassWithSingleProperty
            ??= WorksheetRowMetadataServices.CreateObjectInfo<SpreadCheetah.SourceGenerator.SnapshotTest.Models.RecordClassWithSingleProperty>(AddHeaderRow0Async, AddAsRowAsync, AddRangeAsRowsAsync);

        private static async ValueTask AddHeaderRow0Async(SpreadCheetah.Spreadsheet spreadsheet, SpreadCheetah.Styling.StyleId? styleId, CancellationToken token)
        {
            var cells = ArrayPool<StyledCell>.Shared.Rent(1);
            try
            {
                cells[0] = new StyledCell("Value", styleId);
                await spreadsheet.AddRowAsync(cells.AsMemory(0, 1), token);
            }
            finally
            {
                ArrayPool<StyledCell>.Shared.Return(cells, true);
            }
        }

        private static ValueTask AddAsRowAsync(SpreadCheetah.Spreadsheet spreadsheet, SpreadCheetah.SourceGenerator.SnapshotTest.Models.RecordClassWithSingleProperty? obj, CancellationToken token)
        {
            if (spreadsheet is null)
                throw new ArgumentNullException(nameof(spreadsheet));
            if (obj is null)
                return spreadsheet.AddRowAsync(ReadOnlyMemory<DataCell>.Empty, token);
            return AddAsRowInternalAsync(spreadsheet, obj, token);
        }

        private static ValueTask AddRangeAsRowsAsync(SpreadCheetah.Spreadsheet spreadsheet, IEnumerable<SpreadCheetah.SourceGenerator.SnapshotTest.Models.RecordClassWithSingleProperty?> objs, CancellationToken token)
        {
            if (spreadsheet is null)
                throw new ArgumentNullException(nameof(spreadsheet));
            if (objs is null)
                throw new ArgumentNullException(nameof(objs));
            return AddRangeAsRowsInternalAsync(spreadsheet, objs, token);
        }

        private static async ValueTask AddAsRowInternalAsync(SpreadCheetah.Spreadsheet spreadsheet, SpreadCheetah.SourceGenerator.SnapshotTest.Models.RecordClassWithSingleProperty obj, CancellationToken token)
        {
            var cells = ArrayPool<DataCell>.Shared.Rent(1);
            try
            {
                await AddCellsAsRowAsync(spreadsheet, obj, cells, token).ConfigureAwait(false);
            }
            finally
            {
                ArrayPool<DataCell>.Shared.Return(cells, true);
            }
        }

        private static async ValueTask AddRangeAsRowsInternalAsync(SpreadCheetah.Spreadsheet spreadsheet, IEnumerable<SpreadCheetah.SourceGenerator.SnapshotTest.Models.RecordClassWithSingleProperty?> objs, CancellationToken token)
        {
            var cells = ArrayPool<DataCell>.Shared.Rent(1);
            try
            {
                await AddEnumerableAsRowsAsync(spreadsheet, objs, cells, token).ConfigureAwait(false);
            }
            finally
            {
                ArrayPool<DataCell>.Shared.Return(cells, true);
            }
        }

        private static async ValueTask AddEnumerableAsRowsAsync(SpreadCheetah.Spreadsheet spreadsheet, IEnumerable<SpreadCheetah.SourceGenerator.SnapshotTest.Models.RecordClassWithSingleProperty?> objs, DataCell[] cells, CancellationToken token)
        {
            foreach (var obj in objs)
            {
                await AddCellsAsRowAsync(spreadsheet, obj, cells, token).ConfigureAwait(false);
            }
        }

        private static ValueTask AddCellsAsRowAsync(SpreadCheetah.Spreadsheet spreadsheet, SpreadCheetah.SourceGenerator.SnapshotTest.Models.RecordClassWithSingleProperty? obj, DataCell[] cells, CancellationToken token)
        {
            if (obj is null)
                return spreadsheet.AddRowAsync(ReadOnlyMemory<DataCell>.Empty, token);

            cells[0] = new DataCell(obj.Value);
            return spreadsheet.AddRowAsync(cells.AsMemory(0, 1), token);
        }
    }
}
