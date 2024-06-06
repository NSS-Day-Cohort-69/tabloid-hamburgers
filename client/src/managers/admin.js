const _apiUrl = "/api/admin";

export const getAllDemotes = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const postNewDemote = (newDemote) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(newDemote),
  });
};

export const deleteDemote = (deleteDemote) => {
  return fetch(`${_apiUrl}/${deleteDemote.id}`, { method: "DELETE" });
};
