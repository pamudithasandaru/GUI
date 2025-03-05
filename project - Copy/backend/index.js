import express from 'express';
import mysql from 'mysql';
import cors from 'cors';
import morgan from 'morgan';
const app = express();

// Middleware
app.use(cors());
app.use(express.json()); // Parse JSON request body
app.use(morgan("dev"));


// Database Connection
const dbConfig = {
    host: "b5z0tndzf1fcv0vjokql-mysql.services.clever-cloud.com",
    user: "uwmr8hgqcawx1niq",
    password: "cwWpQS2x3E1zltqrQm2g",
    database: "b5z0tndzf1fcv0vjokql",
};

const connection = mysql.createConnection(dbConfig);

connection.connect((err) => {
    if (err) {
        console.error('Error connecting to database:', err.message);
    } else {
        console.log('Database connected');
    }
});

// API Route to Handle Form Submission
app.post('/api/submit-booking', (req, res) => {
    const { customerName, NIC, Time, Beauty, Package, Date } = req.body;

    // Validation: Ensure required fields are provided
    if (!customerName || !NIC || !Time || !Package || !Date) {
        console.log(customerName, NIC, Time, Beauty, Package, Date);
        console.log("isjdsjdj");
        return res.status(400).json({ error: 'All required fields must be filled' });
    }

    // Insert data into MySQL
    const sql = `INSERT INTO bookings (CustomerName, NIC, Time, Beauty, Package, Date) 
                 VALUES (?, ?, ?, ?, ?, ?)`;

    connection.query(sql, [customerName, NIC, Time, Beauty || null, Package, Date], (err, result) => {
        if (err) {
            console.error('Error inserting data:', err.message);
            return res.status(500).json({ error: 'Database error' });
        }
        res.json({ message: 'Booking confirmed successfully' });
    });
});

// Fetch All Bookings
app.get('/api/bookings', (req, res) => {
    const sql = 'SELECT * FROM bookings ORDER BY Date ASC';

    connection.query(sql, (err, results) => {
        if (err) {
            console.error('Error fetching data:', err.message);
            return res.status(500).json({ error: 'Database error' });
        }
        res.json(results);
    });
});

// Default Route
app.get('/', (req, res) => {
    res.send('Server is ready');
});

// Start Server
app.listen(5006, () => {
    console.log('Server is running on port 5006');
});
