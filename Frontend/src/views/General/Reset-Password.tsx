import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { resetPassword } from "../../app/Stores/AuthSlice";
import { ResetPasswordDTO } from "../../models/AuthDtos";
import { AppDispatch } from "../../app/store";
import Input from "../../components/Generics/Input";

const ResetPassword: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();
  const [currentPassword, setCurrentPassword] = useState<string>("");
  const [newPassword, setNewPassword] = useState<string>("");
  const [confirmPassword, setConfirmPassword] = useState<string>("");

  const handleReset = async (e: React.FormEvent) => {
    e.preventDefault();

    const user: ResetPasswordDTO = {
      UserId: localStorage.getItem("UserId")!,
      CurrentPassword: currentPassword,
      NewPassword: newPassword,
      ConfirmPassword: confirmPassword,
    };
    try {
      await dispatch(resetPassword(user));
      setCurrentPassword("");
      setNewPassword("");
      setConfirmPassword("");
    } catch (e) {
      console.error("Error: ", e);
    }
  };

  return (
    <div className="container mt-14 mb-12 text-gray-900 dark:text-white">
      <h1 className="text-4xl font-bold text-center">Reset Password</h1>
      <form
        onSubmit={handleReset}
        className="max-w-md mx-auto mt-8 bg-gray-100 p-8 rounded-lg shadow-md dark:bg-gray-800/90"
      >
        <div className="mb-4">
          <label htmlFor="currentPassword" className="block ">
            Current Password
          </label>
          <Input
            type="text"
            placeholder="Enter Your Current Password"
            value={currentPassword}
            onChange={(e) => setCurrentPassword(e.target.value)}
            required
          />
        </div>
        <div className="mb-4">
          <label htmlFor="newPassword" className="block">
            New Password
          </label>
          <Input
            type="password"
            placeholder="Enter your New Password"
            value={newPassword}
            onChange={(e) => setNewPassword(e.target.value)}
            required
          />
        </div>
        <div className="mb-4">
          <label htmlFor="confirmPassword" className="block">
            Confirm Password
          </label>
          <Input
            type="password"
            placeholder="PleaseConfirm Password"
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
            required
          />
        </div>
        <button
          type="submit"
          className="w-full bg-primary text-white py-3  rounded-lg"
        >
          Save
        </button>
      </form>
    </div>
  );
};

export default ResetPassword;
