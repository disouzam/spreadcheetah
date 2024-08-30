﻿//HintName: MyNamespace.MyGenRowContext.g.cs
// <auto-generated />
#nullable enable
using SpreadCheetah;
using SpreadCheetah.SourceGeneration;
using SpreadCheetah.Styling;
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

        private WorksheetRowTypeInfo<SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithUnsupportedProperty>? _ClassWithUnsupportedProperty;
        public WorksheetRowTypeInfo<SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithUnsupportedProperty> ClassWithUnsupportedProperty => _ClassWithUnsupportedProperty
            ??= WorksheetRowMetadataServices.CreateObjectInfo<SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithUnsupportedProperty>(
                AddHeaderRow0Async, AddAsRowAsync, AddRangeAsRowsAsync, null);

        private static async ValueTask AddHeaderRow0Async(SpreadCheetah.Spreadsheet spreadsheet, SpreadCheetah.Styling.StyleId? styleId, CancellationToken token)
        {
            var cells = ArrayPool<StyledCell>.Shared.Rent(1);
            try
            {
                cells[0] = new StyledCell("Name", styleId);
                await spreadsheet.AddRowAsync(cells.AsMemory(0, 1), token).ConfigureAwait(false);
            }
            finally
            {
                ArrayPool<StyledCell>.Shared.Return(cells, true);
            }
        }

        private static ValueTask AddAsRowAsync(SpreadCheetah.Spreadsheet spreadsheet, SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithUnsupportedProperty? obj, CancellationToken token)
        {
            if (spreadsheet is null)
                throw new ArgumentNullException(nameof(spreadsheet));
            if (obj is null)
                return spreadsheet.AddRowAsync(ReadOnlyMemory<DataCell>.Empty, token);
            return AddAsRowInternalAsync(spreadsheet, obj, token);
        }

        private static ValueTask AddRangeAsRowsAsync(SpreadCheetah.Spreadsheet spreadsheet,
            IEnumerable<SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithUnsupportedProperty?> objs,
            CancellationToken token)
        {
            if (spreadsheet is null)
                throw new ArgumentNullException(nameof(spreadsheet));
            if (objs is null)
                throw new ArgumentNullException(nameof(objs));
            return AddRangeAsRowsInternalAsync(spreadsheet, objs, token);
        }

        private static async ValueTask AddAsRowInternalAsync(SpreadCheetah.Spreadsheet spreadsheet,
            SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithUnsupportedProperty obj,
            CancellationToken token)
        {
            var cells = ArrayPool<DataCell>.Shared.Rent(1);
            try
            {
                var styleIds = Array.Empty<StyleId>();
                await AddCellsAsRowAsync(spreadsheet, obj, cells, styleIds, token).ConfigureAwait(false);
            }
            finally
            {
                ArrayPool<DataCell>.Shared.Return(cells, true);
            }
        }

        private static async ValueTask AddRangeAsRowsInternalAsync(SpreadCheetah.Spreadsheet spreadsheet,
            IEnumerable<SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithUnsupportedProperty?> objs,
            CancellationToken token)
        {
            var cells = ArrayPool<DataCell>.Shared.Rent(1);
            try
            {
                var styleIds = Array.Empty<StyleId>();
                foreach (var obj in objs)
                {
                    await AddCellsAsRowAsync(spreadsheet, obj, cells, styleIds, token).ConfigureAwait(false);
                }
            }
            finally
            {
                ArrayPool<DataCell>.Shared.Return(cells, true);
            }
        }

        private static ValueTask AddCellsAsRowAsync(SpreadCheetah.Spreadsheet spreadsheet,
            SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithUnsupportedProperty? obj,
            DataCell[] cells, IReadOnlyList<StyleId> styleIds, CancellationToken token)
        {
            if (obj is null)
                return spreadsheet.AddRowAsync(ReadOnlyMemory<DataCell>.Empty, token);

            cells[0] = new DataCell(obj.Name);
            return spreadsheet.AddRowAsync(cells.AsMemory(0, 1), token);
        }

        private WorksheetRowTypeInfo<SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithSingleProperty>? _ClassWithSingleProperty;
        public WorksheetRowTypeInfo<SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithSingleProperty> ClassWithSingleProperty => _ClassWithSingleProperty
            ??= WorksheetRowMetadataServices.CreateObjectInfo<SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithSingleProperty>(
                AddHeaderRow1Async, AddAsRowAsync, AddRangeAsRowsAsync, null);

        private static async ValueTask AddHeaderRow1Async(SpreadCheetah.Spreadsheet spreadsheet, SpreadCheetah.Styling.StyleId? styleId, CancellationToken token)
        {
            var cells = ArrayPool<StyledCell>.Shared.Rent(1);
            try
            {
                cells[0] = new StyledCell("Name", styleId);
                await spreadsheet.AddRowAsync(cells.AsMemory(0, 1), token).ConfigureAwait(false);
            }
            finally
            {
                ArrayPool<StyledCell>.Shared.Return(cells, true);
            }
        }

        private static ValueTask AddAsRowAsync(SpreadCheetah.Spreadsheet spreadsheet, SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithSingleProperty? obj, CancellationToken token)
        {
            if (spreadsheet is null)
                throw new ArgumentNullException(nameof(spreadsheet));
            if (obj is null)
                return spreadsheet.AddRowAsync(ReadOnlyMemory<DataCell>.Empty, token);
            return AddAsRowInternalAsync(spreadsheet, obj, token);
        }

        private static ValueTask AddRangeAsRowsAsync(SpreadCheetah.Spreadsheet spreadsheet,
            IEnumerable<SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithSingleProperty?> objs,
            CancellationToken token)
        {
            if (spreadsheet is null)
                throw new ArgumentNullException(nameof(spreadsheet));
            if (objs is null)
                throw new ArgumentNullException(nameof(objs));
            return AddRangeAsRowsInternalAsync(spreadsheet, objs, token);
        }

        private static async ValueTask AddAsRowInternalAsync(SpreadCheetah.Spreadsheet spreadsheet,
            SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithSingleProperty obj,
            CancellationToken token)
        {
            var cells = ArrayPool<DataCell>.Shared.Rent(1);
            try
            {
                var styleIds = Array.Empty<StyleId>();
                await AddCellsAsRowAsync(spreadsheet, obj, cells, styleIds, token).ConfigureAwait(false);
            }
            finally
            {
                ArrayPool<DataCell>.Shared.Return(cells, true);
            }
        }

        private static async ValueTask AddRangeAsRowsInternalAsync(SpreadCheetah.Spreadsheet spreadsheet,
            IEnumerable<SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithSingleProperty?> objs,
            CancellationToken token)
        {
            var cells = ArrayPool<DataCell>.Shared.Rent(1);
            try
            {
                var styleIds = Array.Empty<StyleId>();
                foreach (var obj in objs)
                {
                    await AddCellsAsRowAsync(spreadsheet, obj, cells, styleIds, token).ConfigureAwait(false);
                }
            }
            finally
            {
                ArrayPool<DataCell>.Shared.Return(cells, true);
            }
        }

        private static ValueTask AddCellsAsRowAsync(SpreadCheetah.Spreadsheet spreadsheet,
            SpreadCheetah.SourceGenerator.SnapshotTest.Models.ClassWithSingleProperty? obj,
            DataCell[] cells, IReadOnlyList<StyleId> styleIds, CancellationToken token)
        {
            if (obj is null)
                return spreadsheet.AddRowAsync(ReadOnlyMemory<DataCell>.Empty, token);

            cells[0] = new DataCell(obj.Name);
            return spreadsheet.AddRowAsync(cells.AsMemory(0, 1), token);
        }

        private static DataCell ConstructTruncatedDataCell(string? value, int truncateLength)
        {
            return value is null || value.Length <= truncateLength
                ? new DataCell(value)
                : new DataCell(value.AsMemory(0, truncateLength));
        }
    }
}
