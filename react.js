// Import the necessary dependencies
import React, { useState } from 'react';

// Header component
const Header = () => {
  return (
    <header>
      <nav>
        <ul>
          <li><a href="/">Home</a></li>
          <li><a href="/timetable">Time Table</a></li>
          <li><a href="/registration">Registration</a></li>
        </ul>
      </nav>
    </header>
  );
};

// Image component
const Image = () => {
  return <img src="your_background_image_url" alt="Background" />;
};

// Login component
const Login = () => {
  const [id, setId] = useState('');
  const [password, setPassword] = useState('');

  const handleIdChange = (e) => {
    setId(e.target.value);
  };

  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Add your login logic here
  };

  return (
    <div className="login-container">
      <form onSubmit={handleSubmit}>
        <input type="text" placeholder="ID" value={id} onChange={handleIdChange} />
        <input type="password" placeholder="Password" value={password} onChange={handlePasswordChange} />
        <button type="submit">Login</button>
      </form>
    </div>
  );
};

// Footer component
const Footer = () => {
  return (
    <footer>
      <p>@virtualclassmanagementsystem</p>
    </footer>
  );
};

// Main component
const App = () => {
  return (
    <div className="app">
      <Header />
      <Image />
      <Login />
      <Footer />
    </div>
  );
};

export default App;
