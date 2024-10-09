import { useState, useEffect } from "react";
import Input from "./Input";

export interface TableColumn {
  label: string;
  field: string;
  sortable?: boolean;
  render?: (value: any, row: any) => JSX.Element;
}

interface Pagination {
  page: number;
  rowsPerPage: number;
  totalItems?: number;
}

interface TableProps {
  columns: TableColumn[];
  data: any[];
  pagination?: Pagination;
  noDataLabel?: string;
  onRowClick?: (item: Record<string, any>) => void;
}

const MainTable = ({
  columns,
  data,
  pagination = { page: 1, rowsPerPage: 10, totalItems: data.length },
  noDataLabel = "No Data",
  onRowClick,
}: TableProps) => {
  const [filteredData, setFilteredData] = useState<any[]>([]);
  const [paginatedData, setPaginatedData] = useState<any[]>([]);
  const [currentPagination, setCurrentPagination] =
    useState<Pagination>(pagination);
  const [filter, setFilter] = useState<string>("");

  const totalPages = Math.ceil(
    filteredData.length / currentPagination.rowsPerPage
  );

  const handlePreviousPage = () => {
    if (currentPagination.page > 1) {
      setCurrentPagination((prev) => ({
        ...prev,
        page: prev.page - 1,
      }));
    }
  };

  const handleNextPage = () => {
    if (currentPagination.page < totalPages) {
      setCurrentPagination((prev) => ({
        ...prev,
        page: prev.page + 1,
      }));
    }
  };

  const renderCellContent = (row: any, col: TableColumn) => {
    const cellData = row[col.field];

    if (col.render) {
      return col.render(cellData, row);
    }

    if (typeof cellData === "string" && cellData.startsWith("data:image")) {
      return (
        <img
          src={cellData}
          alt="Image"
          style={{ width: "50px", height: "50px", objectFit: "cover" }}
        />
      );
    }
    return String(cellData);
  };

  useEffect(() => {
    const filterData = data.filter((row: any) =>
      columns.some((col) =>
        String(row[col.field]).toLowerCase().includes(filter.toLowerCase())
      )
    );
    setFilteredData(filterData);
  }, [filter, data, columns]);

  useEffect(() => {
    const start = (currentPagination.page - 1) * currentPagination.rowsPerPage;
    const end = start + currentPagination.rowsPerPage;
    setPaginatedData(filteredData.slice(start, end));
  }, [currentPagination, filteredData]);

  return (
    <div className="flex justify-center w-full">
      <div className="w-full p-4">
        <div className="flex justify-end mb-4 text-black dark:text-white">
          <Input
            type="text"
            value={filter}
            onChange={(e) => setFilter(e.target.value)}
            placeholder="Search"
          />
        </div>
        <div className="overflow-x-auto">
          <table className="min-w-full table-auto border-collapse border border-gray-300">
            <thead className="bg-gray-200">
              <tr>
                {columns.map((col, idx) => (
                  <th
                    key={idx}
                    className="px-4 py-2 text-left font-semibold text-gray-700 border border-gray-300"
                  >
                    {col.label}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {paginatedData.length > 0 ? (
                paginatedData.map((row, rowIndex) => (
                  <tr
                    key={rowIndex}
                    className="hover:bg-gray-100 dark:hover:bg-gray-700 cursor-pointer"
                    onClick={() => onRowClick && onRowClick(row)}
                  >
                    {columns.map((col, colIndex) => (
                      <td
                        key={colIndex}
                        className="px-4 py-2 border border-gray-300"
                      >
                        {renderCellContent(row, col)}
                      </td>
                    ))}
                  </tr>
                ))
              ) : (
                <tr>
                  <td
                    colSpan={columns.length}
                    className="text-center p-4 text-gray-500"
                  >
                    {noDataLabel}
                  </td>
                </tr>
              )}
            </tbody>
          </table>

          <div className="flex justify-between items-center mt-4">
            <div>
              Page {currentPagination.page} of {totalPages}
            </div>
            <div className="flex space-x-2">
              <button
                className="px-3 py-1 border border-gray-300 rounded disabled:opacity-50"
                disabled={currentPagination.page === 1}
                onClick={handlePreviousPage}
              >
                Previous
              </button>
              <button
                className="px-3 py-1 border border-gray-300 rounded disabled:opacity-50"
                disabled={currentPagination.page >= totalPages}
                onClick={handleNextPage}
              >
                Next
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default MainTable;
