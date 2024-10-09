import React from "react";
import Hero from "../../components/Hero/Hero";
import TopProducts from "../../components/TopProduct/TopProducts";
import Banner from "../../components/Banner/Banner";
import Testimonials from "../../components/Testimonials/Testimonials";
import Product from "./Product";

const Home: React.FC = () => {
  return (
    <>
      <Hero />
      <TopProducts />
      <Product />
      <Banner />
      <Testimonials />
    </>
  );
};

export default Home;
