# Library Management Mobile Application

This cross-platform mobile application enables users to interact with a library's book collection, providing a seamless experience for logging in, viewing available books, and managing book checkouts and returns. The application consists of two main screens: a Login Screen and a Books List Screen.

Features:
<ul>
    <li>
        <strong>Login Screen:</strong> Users can sign in using a simple form that validates credentials. The app supports two predefined users (Peter and Mary) for authentication.
    </li>
    <li>
        <strong>Books List Screen:</strong> After successful login, users are greeted with a personalized welcome message and a dynamic list of books loaded from an SQLite database. Users can view the status of each book (available, checked out by another user, or checked out by the current user).
    </li>
    <li>
        <strong>Book Management:</strong> Users can check out and return books using context actions. The app ensures that only available books can be borrowed and that only the user who borrowed a book can return it.
    </li>
    <li>
        <strong>Data Persistence:</strong> Book data is persisted using SQLite with prepopulated entries to simulate a real library. The sqlite-net-pcl library is used for database management.
    </li>
    <li>
        <strong>User Notifications:</strong> Users receive popup messages indicating the success or failure of their borrowing or returning actions, enhancing user interaction and feedback.
    </li>
    <li>
        <strong>Navigation:</strong> The app uses hierarchical navigation to ensure smooth transitions between the Login Screen and the Books List Screen. The back navigation returns users to a cleared login form, ensuring a fresh start for each session.
    </li>
</ul>






