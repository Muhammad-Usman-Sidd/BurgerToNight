import HeroPic1 from "../../assets/Images/MenuDeals/hero.jpg";
import HeroPic2 from "../../assets/Images/MenuItems/Grilled Chicken Wrap.jpg";
import HeroPic3 from "../../assets/Images/MenuItems/Chicken Broast.jpg";
import Slider from "react-slick";
import React from "react";
import { Link } from "react-router-dom";

interface ImageData {
  id: number;
  img: string;
  title: string;
  description: string;
}

const ImageList: ImageData[] = [
  {
    id: 1,
    img: HeroPic1,
    title: "Up to 50% on Your Favorite Deals!",
    description:
      "Transform your meal experience with massive savings! Enjoy up to 50% off on our special deals. Don’t miss out on the flavors that will change your day.",
  },
  {
    id: 2,
    img: HeroPic2,
    title: "Get 20% Off on Delicious Wraps!",
    description:
      "Savor the deliciousness of our wraps, now with a flat 20% discount. Taste the perfection, grab yours today!",
  },
  {
    id: 3,
    img: HeroPic3,
    title: "Grab a Chicken Bucket at 15% Off!",
    description:
      "Enjoy our mouth-watering chicken bucket with a 15% discount! Crispy, juicy, and irresistibly delicious.",
  },
];

const Hero: React.FC = () => {
  const settings = {
    dots: false,
    arrows: false,
    infinite: true,
    speed: 800,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 4000,
    cssEase: "ease-in-out",
    pauseOnHover: false,
    pauseOnFocus: true,
  };

  return (
    <div className="relative overflow-hidden min-h-[550px] sm:min-h-[650px] bg-gray-100 flex justify-center items-center dark:bg-gray-950 dark:text-white duration-200 ">
      <div className="h-[700px] w-[700px] bg-primary/40 absolute -top-1/2 left-0 rounded-3xl rotate-45 -z[8]"></div>
      <div className="container pb-8 sm:pb-0">
        <Slider {...settings}>
          {ImageList.map((data) => (
            <div key={data.id}>
              <div className="grid grid-cols-1 sm:grid-cols-2">
                <div className="flex flex-col justify-center gap-4 pt-12 sm:pt-0 text-center sm:text-left order-2 sm:order-1 relative z-10">
                  <h1
                    data-aos="zoom-out"
                    data-aos-duration="500"
                    data-aos-once="true"
                    className="text-5xl sm:text-6xl lg:text-7xl font-bold"
                  >
                    {data.title}
                  </h1>
                  <p
                    data-aos="fade-up"
                    data-aos-duration="500"
                    data-aos-delay="100"
                    className="text-sm"
                  >
                    {data.description}
                  </p>
                  <div
                    data-aos="fade-up"
                    data-aos-duration="500"
                    data-aos-delay="300"
                  >
                    <Link
                      to="/deals"
                      className="bg-gradient-to-r from-primary to-secondary hover:scale-105 duration-200 text-white py-2 px-4 rounded-full"
                    >
                      Order Now
                    </Link>
                  </div>
                </div>
                <div className="order-1 sm:order-2">
                  <div
                    data-aos="zoom-in"
                    data-aos-once="true"
                    className="relative z-10"
                  >
                    <img
                      src={data.img}
                      alt=""
                      className="w-[300px] h-[300px] sm:h-[450px] sm:w-[450px] sm:scale-105 lg:scale-120 object-contain mx-auto"
                    />
                  </div>
                </div>
              </div>
            </div>
          ))}
        </Slider>
      </div>
    </div>
  );
};

export default Hero;
