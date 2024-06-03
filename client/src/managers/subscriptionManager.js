export const subscribeToUser = (subscription) =>
{
    return fetch('/api/subscription',
        {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(subscription)
        })
}



export const unsubscribeToUser = (followerId , subscriberId) =>
{
    return fetch(`/api/subscription?followerId=${followerId}&subscriberId=${subscriberId}`,
        {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({followerId , subscriberId})
        })
}
