import React from "react";
import Button from "./Button";
import MainTable, { TableColumn } from "./MainTable";

export interface ColumnModel {
  name: string;
  label: string;
  field: string | ((row: any) => any);
  sortable?: boolean;
  required?: boolean;
  override?: boolean;
  render?: (value: any, row: any) => JSX.Element;
}

interface TableWrapperProps {
  title: string;
  columns: TableColumn[];
  data: any[];
  hasCreateAction?: boolean;
  onCreateNew?: () => void;
  onEditAction?: (item: Record<string, any>) => void;
}

const TableWrapper: React.FC<TableWrapperProps> = ({
  title,
  columns,
  data,
  hasCreateAction,
  onCreateNew,
  onEditAction,
}) => {
  return (
    <div className="pb-5">
      <div className="flex justify-center items-center mt-6">
        {hasCreateAction && (
          <Button variant="primary" className="m-3" onClick={onCreateNew}>
            Create New
          </Button>
        )}
        <h4 className="text-2xl m-3 text-center">{title}</h4>
      </div>
      <MainTable data={data} columns={columns} onRowClick={onEditAction} />
    </div>
  );
};

export default TableWrapper;
