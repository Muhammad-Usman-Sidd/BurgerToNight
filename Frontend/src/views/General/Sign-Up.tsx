import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { register } from "../../app/Stores/AuthSlice";
import { useNavigate } from "react-router-dom";
import { RegistrationRequestDTO } from "../../models/AuthDtos";
import { toast } from "react-toastify";
import { Link } from "react-router-dom";
import { AppDispatch } from "../../app/store";
import Input from "../../components/Generics/Input";

const SignUp: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [address, setAddress] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState("customer");
  const [secretKey, setSecretKey] = useState("");

  const handleSignUp = async (e: React.FormEvent) => {
    e.preventDefault();
    const user: RegistrationRequestDTO = {
      UserName: userName,
      Email: email,
      PhoneNumber: phoneNumber,
      Address: address,
      Password: password,
      Role: role,
      SecretKey: role === "admin" ? secretKey : "",
    };
    try {
      await dispatch(register(user));
      toast.success("Account created successfully! Please login.");
      setUserName("");
      setEmail("");
      setPhoneNumber("");
      setAddress("");
      setPassword("");
      setRole("customer");
      setSecretKey("");
      navigate("/auth/sign-in");
    } catch (error) {
      console.error("Error: ", error);
    }
  };

  return (
    <div className="container mt-14 mb-12 dark:text-white ">
      <h1 className="text-5xl font-bold text-center">Sign Up</h1>
      <form
        onSubmit={handleSignUp}
        className="max-w-md mx-auto mt-8 bg-gray-100 p-8 rounded-lg shadow-md dark:bg-gray-800/90"
      >
        <div className="mb-4 dark:bg-gray-800">
          <label htmlFor="role" className="block">
            Role
          </label>
          <select
            id="role"
            value={role}
            onChange={(e) => setRole(e.target.value)}
            className="w-full p-1 text-black dark:text-white dark:bg-gray-800 border rounded-lg"
          >
            <option value="customer">Customer</option>
            <option value="admin">Admin</option>
          </select>
        </div>
        <div className="mb-4">
          <label htmlFor="userName" className="block">
            Username
          </label>
          <Input
            type="text"
            placeholder="Enter your UserName"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
            required
          />
        </div>

        <div className="mb-4">
          <label htmlFor="email" className="block ">
            Email
          </label>
          <Input
            type="email"
            placeholder="Enter your Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>

        <div className="my-4">
          <label htmlFor="password" className="block ">
            Password
          </label>
          <Input
            type="password"
            placeholder="Enter Your Passwrod..."
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
            className=""
          />
        </div>

        <div className="my-4">
          <label htmlFor="phoneNumber" className="block ">
            Phone Number
          </label>
          <Input
            type="text"
            placeholder="Enter Your Phone Number..."
            value={phoneNumber}
            onChange={(e) => setPhoneNumber(e.target.value)}
          />
        </div>

        <div className="mb-3">
          <label htmlFor="address" className="block ">
            Address
          </label>
          <Input
            type="text"
            placeholder="Enter Your Address..."
            value={address}
            onChange={(e) => setAddress(e.target.value)}
          />
        </div>

        {role === "admin" && (
          <div className="mb-4">
            <label htmlFor="secretKey" className="block ">
              Secret Key
            </label>
            <Input
              type="text"
              placeholder="Enter Admin's Secret Key..."
              value={secretKey}
              onChange={(e) => setSecretKey(e.target.value)}
              required
            />
          </div>
        )}

        <button
          type="submit"
          className="w-full bg-primary text-white py-3 rounded-lg"
        >
          Sign Up
        </button>
      </form>

      <div className="text-center mt-4">
        <p>
          Already have an account?{" "}
          <Link to="/auth/sign-in" className="text-primary">
            Sign In
          </Link>
        </p>
      </div>
    </div>
  );
};

export default SignUp;
