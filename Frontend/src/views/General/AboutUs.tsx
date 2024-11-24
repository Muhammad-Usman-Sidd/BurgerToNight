import React from "react";
import TeamPic from "../../assets/Images/MenuDeals/PizzaLargeBundle.webp";
import AboutHeroPic from "../../assets/Images/MenuDeals/hero.jpg";

const AboutUs: React.FC = () => {
  return (
    <div className="about-page">
      <section className="relative overflow-hidden bg-gray-100 dark:bg-gray-900 text-gray-800 dark:text-gray-100 py-12">
        <div className="container mx-auto flex flex-col lg:flex-row items-center justify-between">
          <div className="lg:w-1/2 text-center lg:text-left">
            <h1 className="text-4xl sm:text-5xl font-bold leading-tight">
              Welcome to Burger To Night
            </h1>
            <p className="mt-4 text-lg sm:text-xl">
              Your destination for exceptional food experiences. From our
              kitchen to your table, we bring passion, taste, and quality.
            </p>
          </div>
          <div className="lg:w-1/2">
            <img
              src={AboutHeroPic}
              alt="About Us Hero"
              className="rounded-lg shadow-lg object-cover h-[400px] w-full"
            />
          </div>
        </div>
      </section>

      <section className="py-16 bg-white dark:bg-gray-800">
        <div className="container mx-auto text-center">
          <h2 className="text-3xl font-bold mb-8">Our Story</h2>
          <p className="max-w-3xl mx-auto text-lg">
            At Burger To Night, we started with a simple vision: to bring
            delicious, high-quality meals to our community. What began as a
            small family venture has grown into a beloved restaurant, where
            every meal is crafted with care, love, and attention to detail.
          </p>
        </div>
      </section>

      <section className="py-16 bg-gray-50 dark:bg-gray-900 text-gray-800 dark:text-gray-100">
        <div className="container mx-auto text-center">
          <h2 className="text-3xl font-bold mb-8">Our Mission</h2>
          <p className="max-w-3xl mx-auto text-lg">
            We are committed to providing exceptional food experiences, focusing
            on quality ingredients, innovative flavors, and impeccable customer
            service. Whether dining in or enjoying from the comfort of your
            home, we aim to make every bite memorable.
          </p>
        </div>
      </section>

      <section className="py-16 bg-white dark:bg-gray-800">
        <div className="container mx-auto text-center">
          <h2 className="text-3xl font-bold mb-8">Meet Our Team</h2>
          <div className="flex justify-center">
            <img
              src={TeamPic}
              alt="Our Team"
              className="rounded-lg shadow-lg object-cover w-[500px] h-[350px]"
            />
          </div>
          <p className="max-w-2xl mx-auto text-lg mt-8">
            Our dedicated team of chefs, kitchen staff, and customer service
            professionals work together to ensure every experience at
            [Restaurant Name] is delightful. We believe in teamwork, passion,
            and the joy of serving our customers.
          </p>
        </div>
      </section>

      <section className="py-16 bg-primary/90 text-white">
        <div className="container mx-auto text-center">
          <h2 className="text-3xl font-bold mb-8">What Our Customers Say</h2>
          <p className="max-w-3xl mx-auto text-lg">
            "Absolutely love the food here! Always fresh, delicious, and packed
            with flavor. Their chicken wraps are to die for!"
          </p>
          <p className="text-sm mt-4">- Happy Customer</p>
        </div>
      </section>
    </div>
  );
};

export default AboutUs;
