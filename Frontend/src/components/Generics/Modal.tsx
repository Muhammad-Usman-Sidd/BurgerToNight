import React from "react";
import Button from "./Button";

interface ModalProps {
  title: string;
  btnTitle1: string;
  onClose: () => void;
  onConfirm: () => any;
  children: React.ReactNode;
  showDeleteButton?: boolean;
  onDelete?: () => void;
}

export const Modal: React.FC<ModalProps> = ({
  title,
  btnTitle1,
  onClose,
  onConfirm,
  children,
  showDeleteButton = false,
  onDelete,
}) => {
  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
      <div className="bg-gray-100 dark:bg-gray-800 rounded-lg shadow-xl w-[600px] max-w-[700px] max-h-[90vh] p-6 relative overflow-y-auto">
        <div className="flex justify-between items-center mb-4">
          <h2 className="text-lg font-semibold text-gray-800 dark:text-white">
            {title}
          </h2>
          <button
            className="text-gray-600 dark:text-gray-300 hover:text-gray-800 dark:hover:text-gray-100"
            onClick={onClose}
          >
            ✕
          </button>
        </div>
        <div className="mb-6 text-gray-800 dark:text-gray-100">{children}</div>
        <div className="flex justify-end space-x-3">
          <Button
            className="rounded-md"
            variant="light"
            color="gray"
            onClick={onClose}
          >
            Cancel
          </Button>
          {showDeleteButton && onDelete && (
            <Button
              className="rounded-md"
              color="red"
              variant="light"
              onClick={onDelete}
            >
              Delete
            </Button>
          )}
          <Button
            className="rounded-md"
            color="red"
            variant="dark"
            onClick={onConfirm}
          >
            {btnTitle1 ? btnTitle1 : "Confirm"}
          </Button>
        </div>
      </div>
    </div>
  );
};
