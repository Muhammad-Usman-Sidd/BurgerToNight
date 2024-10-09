import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import Button from "../../components/Generics/Button";
import Input from "../../components/Generics/Input";
import { useNavigate } from "react-router-dom";
import { ContactDTO } from "../../models/AuthDtos";

const ContactUs: React.FC = () => {
  const navigate = useNavigate();
  const { user } = useSelector((state: RootState) => state.auth);
  const [formDetails, setFormDetails] = useState<ContactDTO>({
    UserId: "",
    Name: "",
    Message: "",
    Email: "",
  });

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormDetails((prevDetails) => ({
      ...prevDetails,
      [name]: value,
    }));
  };
  const handleSubmit = async () => {
    try {
      console.log(formDetails);
      navigate("/");
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    if (user.Id) {
      setFormDetails({
        UserId: user.Id,
        Name: "",
        Message: "",
        Email: "",
      });
    }
  }, [user]);
  return (
    <div className="contact-page">
      <section className="relative overflow-hidden bg-gray-100 dark:bg-gray-900 text-gray-800 dark:text-gray-100 py-12">
        <div className="container mx-auto text-center">
          <h1 className="text-4xl font-bold">Get in Touch</h1>
          <p className="mt-4 text-lg">
            We're here to help! Reach out to us for any questions, feedback, or
            assistance.
          </p>
        </div>
      </section>

      <section className="py-16 bg-white dark:bg-gray-800">
        <div className="container mx-auto flex flex-col lg:flex-row items-center justify-around">
          <div className="lg:w-1/3 text-center lg:text-left">
            <h2 className="text-2xl font-bold mb-4">Contact Information</h2>
            <p>
              <strong>Address:</strong> DHA Phase-II,Islamabad
            </p>
            <p>
              <strong>Email:</strong> usman.the.coder@gmail.com
            </p>
            <p>
              <strong>Phone:</strong> +92 336 529 1751
            </p>
          </div>

          <div className="lg:w-2/3 mt-8 lg:mt-0">
            <form
              onSubmit={handleSubmit}
              className="bg-gray-100 p-8 rounded-lg shadow-md dark:bg-gray-900"
            >
              <div className="mb-4">
                <label className="block text-lg font-semibold">Name</label>
                <Input
                  type="text"
                  name="Name"
                  value={formDetails.Name}
                  onChange={handleInputChange}
                  placeholder="Enter your name"
                />
              </div>
              <div className="mb-4">
                <label className="block text-lg font-semibold">Email</label>
                <Input
                  type="email"
                  name="Email"
                  value={formDetails.Email}
                  onChange={handleInputChange}
                  className="w-full p-3 rounded-md border border-gray-300 focus:border-primary focus:outline-none dark:bg-gray-800 dark:border-gray-700"
                  placeholder="Enter your email"
                />
              </div>
              <div className="mb-4">
                <label className="block text-lg font-semibold">Message</label>
                <Input
                  name="Message"
                  value={formDetails.Message}
                  onChange={handleInputChange}
                  placeholder="Type your message"
                ></Input>
              </div>
              <Button
                type="submit"
                variant="primary"
                className="w-full rounded-none"
              >
                Send Message
              </Button>
            </form>
          </div>
        </div>
      </section>

      <section className="py-16 bg-gray-100 dark:bg-gray-900">
        <div className="container mx-auto text-center">
          <h2 className="text-2xl font-bold mb-8">Find Us</h2>
          <iframe
            title="Google Maps"
            className="w-full h-72 rounded-md"
            src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3312.937682419213!2d73.0479!3d33.6844!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x38dfbd73ed2d8b45%3A0x6f2237c55b3d5b7!2sDHA%20Phase%202!5e0!3m2!1sen!2s!4v1633976363294!5m2!1sen!2s"
            width="600"
            height="450"
            allowFullScreen
            loading="lazy"
          ></iframe>
        </div>
      </section>
    </div>
  );
};

export default ContactUs;
