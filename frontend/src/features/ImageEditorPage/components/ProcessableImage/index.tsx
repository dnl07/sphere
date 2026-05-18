import { useEffect, useState } from "react"
import LoadingScreen from "../../../../shared/components/LoadingScreen"

type Props = {
    url: string
    filterString: string
    isLoading: boolean
}

const REVEAL_TIME = 1500 // in milliseconds

const ProcessableImage = ({ url, filterString, isLoading }: Props) => {
    const [displayUrl, setDisplayUrl] = useState<string>(url)
    const [prevUrl, setPrevUrl] = useState<string | null>(null)
    const [isRevealing, setIsRevealing] = useState<boolean>(false)

    useEffect(() => {
        if (displayUrl === prevUrl) return

        setPrevUrl(displayUrl)
        setDisplayUrl(url)
        setIsRevealing(true)

        const timeout = setTimeout(() => {
            setPrevUrl(null)
            setIsRevealing(false)
        }, REVEAL_TIME)

        return () => clearTimeout(timeout)
    }, [url])

    return (
        <div className="relative w-full h-full flex items-center justify-center">
            {prevUrl && (
                <img
                    src={prevUrl}
                    className="absolute inset-0 max-w-full max-h-full object-contain"
                    style={{
                        filter: `${filterString}`,
                        animation: isRevealing ? `revealNew ${REVEAL_TIME / 1000}s forwards` : "none",
                    }}
                />
            )}

            <img
                src={displayUrl}
                className="max-w-full max-h-full z-20 object-contain"
                style={{
                    filter: `${filterString}`,
                }}
            />

            {isLoading && (
                <div className="absolute inset-0 z-40 bg-black/50">
                    <LoadingScreen />
                </div>
            )}
        </div>
    )
}

export default ProcessableImage
