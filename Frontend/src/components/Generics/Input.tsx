import React from "react";

interface InputProps {
  type?: string;
  name?: string;
  value?: string | number;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  placeholder?: string;
  className?: string;
  required?: boolean;
}

const Input: React.FC<InputProps> = ({
  type,
  name,
  value,
  onChange,
  placeholder,
  className = "",
  required = false,
}) => {
  return (
    <input
      type={type ? type : "text"}
      name={name}
      value={value}
      onChange={onChange}
      placeholder={placeholder}
      className={`w-full mb-4 px-4 py-2 border border-gray-300 dark:bg-gray-800 dark:border-gray-700 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent transition duration-300 ease-in-out ${className}`}
      required={required}
    />
  );
};

export default Input;
