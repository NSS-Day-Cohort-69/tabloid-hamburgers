export const subscribeToUser = (subscription) =>
{
    return fetch('/api/subscription',
        {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(subscription)
        })
}