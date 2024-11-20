# ElectricityBillPaymentSystem

This project is a backend service for electricity bill vending and payments, designed using an event-driven architecture. The service provides APIs for bill verification, payment processing, and wallet funding, with event publishing and SMS notifications.

Setup and Run Instructions

## Prerequisites
Ensure the following tools are installed on your machine:
.NET SDK 5.0
SQL Server
LocalStack (for mocking AWS SNS/SQS)
Postman or similar API testing tool
## Clone the repository
git clone https://github.com/yourusername/electricity-bill-payment-system.git
cd electricity-bill-payment-system
## Database Configuration
1. Update the connection string in appsettings.json located in the ElectricityBillPaymentSystem.API project:
"ConnectionStrings": {
    "Conn": "Server=localhost\\SQLEXPRESS;Database=ElectricityBillPaymentSystemOne;Trusted_Connection=True;"
}
2. Run migrations to create the database:
 dotnet ef database update --project ElectricityBillPaymentSystem.Persistence

## Run the application

dotnet ef database update --project ElectricityBillPaymentSystem.Persistence

Explanation of Event Handling and Design Decisions
## Event Handling
This project uses an event-driven architecture to decouple components and enable asynchronous communication. Events are published and subscribed using a mocked AWS SNS/SQS implementation:

Published Events:

bill_created: Triggered when a new electricity bill is verified.
payment_completed: Triggered upon successful payment processing.
funds_added: Triggered when funds are added to a wallet.
Event Flow:

Events are serialized and sent to mock AWS SQS queues for simulation.
Subscribers listen to these queues and handle events, simulating real-world scenarios.

## Design Decisions
Wallet Creation: Wallet creation is integrated into the "Add Funds" operation. If the wallet doesn't exist, it is automatically created.
Mocking: AWS SNS/SQS and SMS gateways are mocked to simplify setup and demonstrate functionality without requiring live services.
Event-Driven Architecture: Chosen for scalability and decoupled communication between services, allowing easy extension for future requirements.

SMS Notification Configuration and Usage
## Configuration
A mock implementation logs SMS notifications to the console. Replace this with actual gateway integration if required.

## Usage
SMS notifications are triggered for the following events:

Bill Creation: Notifies the user with the bill details.
Successful Payment: Confirms payment completion.
Low Wallet Balance: Warns the user if their wallet balance falls below a configurable threshold.
Example Notification Workflow:
When a bill is verified:
Message: "Your electricity bill of $100 has been created. Reference: ABC123."
Upon successful payment:
Message: "Payment of $100 for bill reference ABC123 has been successfully processed."
Low balance warning:
Message: "Your wallet balance is below $10. Please top up to avoid interruptions."
