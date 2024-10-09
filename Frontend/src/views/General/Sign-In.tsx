import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { login } from "../../app/Stores/AuthSlice";
import { LoginDTO } from "../../models/AuthDtos";
import { AppDispatch } from "../../app/store";
import Input from "../../components/Generics/Input";

const SignIn: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();
  const [userName, setUserName] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  const handleSignIn = async (e: React.FormEvent) => {
    e.preventDefault();

    const user: LoginDTO = {
      UserName: userName,
      Password: password,
    };

    try {
      await dispatch(login(user));
      setUserName("");
      setPassword("");
    } catch (e) {
      console.error("Error: ", e);
    }
  };

  return (
    <div className="container mt-14 mb-12 text-gray-900 dark:text-white">
      <h1 className="text-5xl font-bold text-center">Sign In</h1>
      <form
        onSubmit={handleSignIn}
        className="max-w-md mx-auto mt-8 bg-gray-100 p-8 rounded-lg shadow-md dark:bg-gray-800/90"
      >
        <div className="mb-4">
          <label htmlFor="userName" className="block ">
            UserName
          </label>
          <Input
            type="text"
            placeholder="Enter Your User Name"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
            required
          />
        </div>
        <div className="mb-4">
          <label htmlFor="password" className="block">
            Password
          </label>
          <Input
            type="password"
            placeholder="Enter your Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <button
          type="submit"
          className="w-full bg-primary text-white py-3  rounded-lg"
        >
          Sign In
        </button>
      </form>
      <div className="text-center mt-4">
        <p>
          Don't have an account?{" "}
          <a href="/auth/sign-up" className="text-primary">
            Sign Up
          </a>
        </p>
      </div>
    </div>
  );
};

export default SignIn;
