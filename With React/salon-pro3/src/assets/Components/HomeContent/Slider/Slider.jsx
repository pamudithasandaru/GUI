
import React, { useState, useEffect } from 'react';
import '../../HomeContent/Slider/Slider.css'; // Import your CSS here
import slider4 from '../../homeassets/slider4.jpg';
import slider1 from '../../homeassets/slider4.jpg';
import slider2 from '../../homeassets/slider4.jpg';
import slider3 from '../../homeassets/slider4.jpg';
import slider5 from '../../homeassets/slider4.jpg';

const Slider= () => {
  const [itemActive, setItemActive] = useState(0);
  const items = [
    {
      image: {slider4},
      heading: 'Your Glow, Our Goal.',
      description:
        'Welcome to Beauty lab, where you can relax and enjoy life. A little peace in a crazy world goes a long way.',
    },
    {
      image: {slider1},
      heading: 'Skin Care.',
      description:
        'Welcome to Beauty lab, where you can relax and enjoy life. A little peace in a crazy world goes a long way.',
    },
    {
      image: {slider2},
      heading: 'Beauty, Simplified.',
      description:
        'Welcome to Beauty lab, where you can relax and enjoy life. A little peace in a crazy world goes a long way.',
    },
    {
      image: {slider3},
      heading: 'Service with Heart.',
      description:
        'Welcome to Beauty lab, where you can relax and enjoy life. A little peace in a crazy world goes a long way.',
    },
    {
      image: {slider5},
      heading: 'Art at Your Fingertips.',
      description:
        'Welcome to Beauty lab, where you can relax and enjoy life. A little peace in a crazy world goes a long way.',
    },
  ];

  const countItem = items.length;

  const handleNext = () => {
    setItemActive((prev) => (prev + 1) % countItem);
  };

  const handlePrev = () => {
    setItemActive((prev) => (prev - 1 + countItem) % countItem);
  };

  useEffect(() => {
    const refreshInterval = setInterval(() => {
      handleNext();
    }, 10000);

    return () => clearInterval(refreshInterval);
  }, []);

  return (
    <div className="slider">
      <div className="list">
        {items.map((item, index) => (
          <div
            className={`item ${index === itemActive ? 'active' : ''}`}
            key={index}
          >
            <img src={item.image} alt={`Slide ${index + 1}`} />
            <div className="content">
              <h2>{item.heading}</h2>
              <p>{item.description}</p>
            </div>
          </div>
        ))}
      </div>
      <div className="arrows">
        <button id="prev" onClick={handlePrev}>
          &lt;
        </button>
        <button id="next" onClick={handleNext}>
          &gt;
        </button>
      </div>
      <div className="thumbnail">
        {items.map((_, index) => (
          <div
            className={`item ${index === itemActive ? 'active' : ''}`}
            key={index}
            onClick={() => setItemActive(index)}
          />
        ))}
      </div>
    </div>
  );
};

export default Slider;
