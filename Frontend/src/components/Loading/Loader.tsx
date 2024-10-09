import React from "react";
import { BeatLoader } from "react-spinners";
import logo from "../../assets/product/logo.png";

const Loader: React.FC = () => {
  return (
    <div className="fixed inset-0 bg-white dark:bg-gray-800 bg-opacity-95 z-50 flex flex-col justify-center items-center">
      <div className="mb-5 animate-bounce">
        <img
          src={logo}
          alt="Restaurant Logo"
          className="w-24 h-24 object-contain"
        />
      </div>

      <div className="flex justify-center items-center">
        <BeatLoader color={"#4287f5"} size={15} margin={2} />
      </div>

      <div className="mt-5 text-xl font-semibold dark:text-white animate-pulse">
        Preparing something delicious...
      </div>
    </div>
  );
};

export default Loader;
