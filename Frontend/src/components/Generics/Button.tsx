import React from "react";

interface ButtonProps {
  onClick?: () => void;
  children: React.ReactNode;
  variant?: "primary" | "light" | "dark" | "outline";
  size?: "small" | "medium" | "large";
  color?: "blue" | "red" | "gray";
  disabled?: boolean;
  className?: string;
  type?: "button" | "submit" | "reset";
}
const Button: React.FC<ButtonProps> = ({
  onClick,
  children,
  disabled,
  variant = "primary",
  size = "medium",
  color = "primary",
  className = "",
  type = "button",
}) => {
  const baseStyles =
    "inline-flex justify-center items-center transition-transform duration-300 ease-in-out focus:outline-none ring-offset-2 rounded-full hover:scale-105";

  const colorStyles: any = {
    red: "bg-red-600 text-white hover:bg-red-500 dark:bg-red-700 dark:hover:bg-red-600",
    blue: "bg-blue-600 text-white hover:bg-blue-500 dark:bg-blue-700 dark:hover:bg-blue-600",
    gray: "bg-gray-600 text-white hover:bg-gray-500 dark:bg-gray-700 dark:hover:bg-gray-600",
  };

  const variantStyles = {
    primary: `bg-primary hover:scale-105 duration-300 text-white py-1 px-4 rounded-full mt-4 group-hover:bg-white group-hover:text-primary`,
    light: `${colorStyles[color]} bg-opacity-80`,
    dark: `${colorStyles[color]} `,
    outline: `border border-${color}-500 text-${color}-700 hover:bg-${color}-50 dark:border-${color}-300 dark:text-${color}-200 dark:hover:bg-${color}-800`,
  };

  const sizeStyles = {
    small: "px-3 py-1 text-sm",
    medium: "px-4 py-2 text-base",
    large: "px-5 py-3 text-lg",
  };

  return (
    <button
      onClick={onClick}
      type={type}
      disabled={disabled}
      className={`${baseStyles} ${variantStyles[variant]} ${sizeStyles[size]} ${className}`}
    >
      {children}
    </button>
  );
};

export default Button;
